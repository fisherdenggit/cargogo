function formatTime(date) {
  var year = date.getFullYear()
  var month = date.getMonth() + 1
  var day = date.getDate()

  var hour = date.getHours()
  var minute = date.getMinutes()
  var second = date.getSeconds()


  return [year, month, day].map(formatNumber).join('/') + ' ' + [hour, minute, second].map(formatNumber).join(':')
}

function formatNumber(n) {
  n = n.toString()
  return n[1] ? n : '0' + n
}

//获取当前微信小程序用户的openId和昵称，存入页面变量中
function loadOpenId(openId, nickName) {
  if (openId == null) {
    var loginCode
    /*第一次调用wx.login()，以获取openId和nickName*/
    wx.login({
      success: function(res) {
        /*以下为向微信小程序登录服务器换取登录令牌*/
        loginCode = res.code
        wx.request({
          url: 'https://api.weixin.qq.com/sns/jscode2session?appid=wx7e6c11974fbb3699&secret=a2af134685148f465721879f6ceab094&js_code=' + loginCode + '&grant_type=authorization_code',
          success: function(res) {
            console.log("this is sessionKey: " + res.data["session_key"])
            openId = res.data.openid
            console.log("this is openId: " + openId)
          },
          fail: function(res) {
            console.log("换取登录令牌失败")
          }
        })
        /*以上为向微信小程序登录服务器换取登录令牌*/

        /*以下为用openId通过wx.getUserInfo()的不经用户授权方式获取用户信息中的nickName*/
        //var nickName
        wx.getUserInfo({
          openIdList: ['selfOpenId'],
          lang: 'zh_CN',
          success: function(res) {
            nickName = res.userInfo.nickName
            console.log('this is the nickName: ' + nickName)
          }
        })
        /*以上为用openId通过wx.getUserInfo()的不经用户授权方式获取用户信息中的nickName*/
      }
    })
  }
}

//根据基础数据表名称、微信昵称装载对应的基础数据表数据进results中，并将第1条记录装载进reslut中在页面中显示，that用于异步回调setData()方法绑定刷新数据
function getFullTableDataFromODataService(serviceName, nickName, result, results, recordPosition, that) {
  if (results.length == 0) {
    wx.login({
      success: function(res) {
        //微信的login方法返回“成功”时获取为第三方服务器ODataService准备的loginCode
        var loginCode = res.code
        console.log('this is loginCode for ODataService:' + loginCode)
        //从微信小程序端向第三方服务器的ODataService发起HTTP的REQUEST请求
        console.log(results.length)
        //if (results.length==0){
        //serviceName+='(\''+recordIds[recordPosition]+'\')'
        wx.request({
          url: 'http://localhost:57499/odata/' + serviceName + '?loginCode=' + loginCode + '&nickName=' + nickName,
          method: 'GET',
          success: function(res) {
            console.log(res)
            console.log(res.data.value[0].CompanyCode)
            console.log(res.data.value.length) //非常重要，这里返回了成功返回的记录条数
            //recordPosition=0
            //result=res.data.value[0].CompanyCode
            //results = new Array()
            for (var index = 0; index < res.data.value.length; index++) {
              var tempResult = new Array()
              if (serviceName == 'bankaccouts') {
                tempResult = [res.data.value[index].ID, res.data.value[index].CompanyCode, res.data.value[index].BankName, res.data.value[index].BankAccount, res.data.value[index].CurrencyCode, res.data.value[index].Note]
              }
              if (serviceName == 'companies') {
                tempResult = [res.data.value[index].ID, res.data.value[index].CompanyCode, res.data.value[index].ShortName, res.data.value[index].FullName, res.data.value[index].BusinessDirectionCode, res.data.value[index].PhoneNumber, res.data.value[index].FaxNumber, res.data.value[index].Website, res.data.value[index].Address, res.data.value[index].TaxNumber, res.data.value[index].SalesContactAddress, res.data.value[index].SalesContact, res.data.value[index].SalesContactMobile, res.data.value[index].SalesContactEmail, res.data.value[index].AccountingContactAddress, res.data.value[index].AccountingContact, res.data.value[index].AccountingContactMobile, res.data.value[index].AccountingContactEmail, res.data.value[index].TotalDeliveryAmount, res.data.value[index].TotalPaymentAmount, res.data.value[index].TotalBalanceAmount, res.data.value[index].TotalUninvoiceAmount, res.data.value[index].CurrencyCode]
              }
              if (serviceName == 'companydeliveryaddresses') {
                tempResult = [res.data.value[index].ID, res.data.value[index].CompanyCode, res.data.value[index].CargoDeliveryAddress, res.data.value[index].CargoDeliveryContact, res.data.value[index].CargoDeliveryContactMobile]
              }
              if (serviceName == 'contracts') {
                tempResult = [res.data.value[index].ID, res.data.value[index].ContractCode, res.data.value[index].ContractDate, res.data.value[index].CompanyCode, res.data.value[index].ProductCode, res.data.value[index].ContractAmount, res.data.value[index].ContractPrice, res.data.value[index].ContractExcutedAmount, res.data.value[index].Note]
              }
              if (serviceName == 'directions') {
                tempResult = [res.data.value[index].ID, res.data.value[index].DirectionCode, res.data.value[index].DirectionDesc]
              }
              if (serviceName == 'invoices') {
                tempResult = [res.data.value[index].ID, res.data.value[index].InvoiceCode, res.data.value[index].InvoiceDate, res.data.value[index].InvoiceAmount, res.data.value[index].InvoiceDirectionCode, res.data.value[index].CompanyCode, res.data.value[index].Note]
              }
              if (serviceName == 'paymenttypes') {
                tempResult = [res.data.value[index].ID, res.data.value[index].PaymentTypeCode, res.data.value[index].PaymentTypeDesc]
              }
              if (serviceName == 'payments') {
                tempResult = [res.data.value[index].ID, res.data.value[index].PaymentDate, res.data.value[index].PaymentDirectionCode, res.data.value[index].CompanyCode, res.data.value[index].PaymentTypeCode, res.data.value[index].PaymentAmount, res.data.value[index].Note]
              }
              if (serviceName == 'products') {
                tempResult = [res.data.value[index].ID, res.data.value[index].ProductCode, res.data.value[index].ProductName, res.data.value[index].Note]
              }
              results[index] = tempResult
            }
            that.setData({
              recordPosition: 0,
              result: results[recordPosition]
              //recordIds:res.data.value.count,
            })
          }
        })
        //}  
      }
    })
  }
}

//通过canvas元素绘制N元（N种颜色）统计饼图
function drawArc(canvasID, x, y, radius, datas, colors, lables) {
  //var canvas=document.getElementById("myCanvas")
  //var context=canvas.getContext("2d")
  var angles = 0
  var context = wx.createCanvasContext(canvasID)
  //context.fillStyle = "#FF00FF"
  //context.setFillStyle('#FFA500')
  for (var index = 0; index < datas.length; index++) {
    angles += datas[index]
  }
  console.log('the angles is' + angles)
  var startAngle = 0
  var endAngle = 0
  var yLabel = 0
  for (var index = 0; index < datas.length; index++) {
    //context.setStrokeStyle('#FFA500')
    endAngle = datas[index] / angles * 2 * Math.PI + startAngle
    console.log('the endAngle is' + endAngle)
    context.beginPath() //“起始一条路径，或重置当前路径”。
    context.setFillStyle(colors[index])
    context.arc(x, y, radius, startAngle, endAngle, false) //“创建弧/曲线（用于创建圆形或部分圆）”。此处参数“boolean counterclockwise 弧度的方向是否是逆时针”貌似无效。
    context.lineTo(x, y) //“添加一个新点，然后在画布中创建从该点到最后指定点的线条”。非常重要的一句，缺失则饼图颜色范围残缺不全
    //context.arc(x, y, radius, startAngle, endAngle)
    //context.arc(x, y, radius, endAngle, startAngle)
    context.closePath() //“创建从当前点回到起始点的路径”。
    //context.stroke() //“绘制已定义的路径”。此处绘制出来的是“圆弧+两端点连线”。
    context.fill()
    startAngle = endAngle
    console.log('the startAngle is' + startAngle)
    //绘制颜色方块
    yLabel += 30
    context.setFillStyle(colors[index])
    context.fillRect(x + 1.5 * radius, yLabel + 0.5 * y, 15, 15)
    //绘制文字说明
    context.setFillStyle('black')
    context.setFontSize(12)
    context.fillText(lables[index] + ': ' + datas[index], x + 1.5 * radius + 20, yLabel + 0.5 * y + 15)
  }
  context.draw()
}

module.exports = {
  formatTime: formatTime,
  loadOpenId: loadOpenId,
  getFullTableDataFromODataService: getFullTableDataFromODataService,
  drawArc: drawArc
}