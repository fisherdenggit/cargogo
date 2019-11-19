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

        /*以下为用openId通过wx.getUserInfo()的不经用户授权方式获取用户信息中的nickName---此方法已被腾讯废弃*/
        //var nickName
        wx.getUserInfo({
          openIdList: ['selfOpenId'],
          lang: 'zh_CN',
          success: function(res) {
            nickName = res.userInfo.nickName
          }
        })
        console.log('this is the nickName: ' + nickName)
        /*以上为用openId通过wx.getUserInfo()的不经用户授权方式获取用户信息中的nickName---此方法已被腾讯废弃*/
        //考虑在此处添加通过用户授权的方式获取其绑定微信的手机号(可与openID一起保存至数据库中为日后再次识别用户做准备)
      }
    })
  }
}

//【旧版本】根据基础数据表名称、微信昵称装载对应的基础数据表数据进results中，并将第1条记录装载进reslut中在页面中显示，
//that用于异步回调setData()方法绑定刷新数据
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
      }
    })
  }
}

//【旧版本】根据基础数据表名称、微信昵称装载对应的基础数据表数据进results中
function getFullTableDataFromODataService2(serviceName, nickName) {
  var tempResults = new Array()
  wx.login({
    success: function(res) {
      //微信的login方法返回“成功”时获取为第三方服务器ODataService准备的loginCode
      var loginCode = res.code
      console.log('this is loginCode for ODataService:' + loginCode)
      //从微信小程序端向第三方服务器的ODataService发起HTTP的REQUEST请求
      console.log(tempResults.length)
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
            tempResults[index] = tempResult
          }
          //that.setData({
          //recordPosition: 0,
          //result: results[recordPosition]
          //recordIds:res.data.value.count,
          //})
        }
      })
    }
  })
  return tempResults
}

//【旧版本】根据基础数据表名称、微信昵称装载对应的基础数据表数据进results中。此方法利用Promise对象实现
function getFullTableDataFromODataService3(serviceName, nickName) {
  var results = new Array()
  return new Promise(function(resolve, reject) {
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
            resolve(results)
          },
          fail: function(res) {
            reject(res)
          }
        })
      }
    })
  })
  //return tempResults
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
    context.arc(x, y, radius, startAngle, endAngle, false) //“创建弧/曲线（用于创建圆形或部分圆）”。
    //此处参数“boolean counterclockwise 弧度的方向是否是逆时针”貌似无效
    context.lineTo(x, y) //“添加一个新点，然后在画布中创建从该点到最后指定点的线条”。非常重要的一句，缺失则饼图颜色范围残缺不全
    //context.arc(x, y, radius, startAngle, endAngle)
    //context.arc(x, y, radius, endAngle, startAngle)
    context.closePath() //“创建从当前点回到起始点的路径”
    //context.stroke() //“绘制已定义的路径”。此处绘制出来的是“圆弧+两端点连线”
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

//【旧版本】调用腾讯地图WebService服务，接受地址，返回对应的纬经度信息(目前可直接输入公司名称，实测返回至少精确到市（区）的纬经度)
function getLatitudeAndLongitudeByAddressFromTencentMapWebService(address, developerKey) {
  var latitudeAndLongitude = null
  return new Promise(function(resolve, reject) {
    wx.request({
      url: 'https://apis.map.qq.com/ws/geocoder/v1/?address=' + address + '&key=' + developerKey,
      method: 'GET',
      success: function(res) {
        console.log(res)
        //res.data.status == '120' "此key每秒请求量已达到上限"
        //res.data.status == '347' "查询无结果"
        //res.data.status == '306' "请求有互斥信息请检查字符串"
        if (res.data.status == '306' || res.data.status == '347') {
          latitudeAndLongitude = [0, 0]
          console.log('输入地址不规范未能找到对应纬经度，返回0,0')
        } else {
          latitudeAndLongitude = [res.data.result.location.lat, res.data.result.location.lng]
          console.log(res.data.result.location)
          console.log(res.data.result.location.lng)
        }
        //console.log(res.data.value.length) //非常重要，这里返回了成功返回的记录条数
        resolve(latitudeAndLongitude)
      },
      fail: function(res) {
        reject(res)
      }
    })
  })

  //return latitudeAndLongitude
}

//【旧版本】根据基础数据表名称、微信昵称装载对应的基础数据表数据进results中，并遍历其中的“公司名称”，调用腾讯地图WebService服务，
//接受“公司名称”，返回对应的纬经度信息，并按照markers属性样式生成markers列表
async function getMarkersList(results, tableName, nickName, markersList, that) {
  if (results == null) {
    try {
      let results = await getFullTableDataFromODataService3(tableName, nickName)
      //console.log(results)
      var index = 0
      var index2 = 0
      //此处通过setInterval与setTimeout实现对异步方法的控制，实现对results中“公司名称”的遍历并调用腾讯地图接口查询其具体纬经度，放入markersList
      var timer = setInterval(async function() {


        //var tempLatitudeAndLongitude
        let tempLatitudeAndLongitude = await getLatitudeAndLongitudeByAddressFromTencentMapWebService(results[index][2], 'HJ4BZ-FWKKP-UCQDO-LNPOL-RDYNS-DEFHH')

        console.log('这是第' + index + '调用腾讯地图接口')
        //markersList[i]={id:index,}
        if (tempLatitudeAndLongitude[0] > 0) {
          markersList[index2] = {
            id: index2,
            latitude: tempLatitudeAndLongitude[0],
            longitude: tempLatitudeAndLongitude[1],
            // alpha:0,
            callout: {
              content: results[index][2],
              padding: 10,
              display: 'ALWAYS',
              textAlign: 'center'
              // borderRadius: 10,
              // borderColor:'#ff0000',
              // borderWidth: 2,
            }
          }
          index2++
        }
        index++
      }, 260) //res.data.status == '120' "此key每秒请求量已达到上限"。实测腾讯地图接口的每秒请求上限次数为4
      setTimeout(function() {
        clearInterval(timer)
        console.log('循环调用腾讯地图接口的周期设置已结束')
        //console.log(markersList)
        //return markersList
        //目前此处在动态获得markersList后，采取var that=this传入当前线程后，回调that.setData方法绑定当前页面的markers数据
        that.setData({
          markers: markersList //getMarkersFromStaticTop10Customers()
        })
      }, 11000) //res.data.status == '120' "此key每秒请求量已达到上限"。实测腾讯地图接口的每秒请求上限次数为4。“公司信息”表中目前有42条记录
    } catch (error) {
      console.log(error)
    }
  }
  //console.log(results)
}

//【旧版本】通过腾讯地图的“qqmap-wx-jssdk”，根据“公司名称”列表，循环查询“公司名称”，返回对应的纬经度信息。并按照markers属性样式生成markers列表
async function getMarkersList2(companyShortNames, markersList, that) {
  // 引入SDK核心类
  var QQMapWX = require('qqmap-wx-jssdk.js')
  // 实例化API核心类
  var qqmapsdk = new QQMapWX({
    key: 'HJ4BZ-FWKKP-UCQDO-LNPOL-RDYNS-DEFHH' // 必填
  })
  var tempLatLng = [0, 0]
  var index = 0
  var index2 = 0
  try {
    var timer = setInterval(async function() {
      await qqmapsdk.geocoder({
        address: companyShortNames[index].short_name,
        success: function(res) {
          console.log(res)
          //res.data.status == '120' "此key每秒请求量已达到上限"
          //res.data.status == '347' "查询无结果"
          //res.data.status == '306' "请求有互斥信息请检查字符串"
          if (res.status == '306' || res.status == '347') {
            console.log('输入地址不规范未能找到对应纬经度，返回0,0')
          } else {
            //res.data.status == '0' "query ok"
            if (res.status == '0') {
              tempLatLng = [res.result.location.lat, res.result.location.lng]
              //console.log(res.data.result.location)
              //console.log(res.data.result.location.lng)
              //if (tempLatLng[0] > 0) {
              markersList[index2] = {
                id: index2,
                latitude: tempLatLng[0],
                longitude: tempLatLng[1],
                // alpha:0,
                callout: {
                  content: companyShortNames[index].short_name,
                  padding: 10,
                  display: 'ALWAYS',
                  textAlign: 'center'
                  // borderRadius: 10,
                  // borderColor:'#ff0000',
                  // borderWidth: 2,
                }
              }
              index2++
              //}
            }

          }
        },
        fail: function(res) {
          console.log(res)
          //console.log(companyShortNames[index].short_name)
        }
      })
      index++
    }, 251)
    setTimeout(function() {
      clearInterval(timer)
      console.log('循环调用腾讯地图接口的周期设置已结束')
      //console.log(markersList)
      //return markersList
      //目前此处在动态获得markersList后，采取var that=this传入当前线程后，回调that.setData方法绑定当前页面的markers数据
      console.log(markersList)
      that.setData({
        markers: markersList //getMarkersFromStaticTop10Customers()
      })
    }, 11000) //res.data.status == '120' "此key每秒请求量已达到上限"。实测腾讯地图接口的每秒请求上限次数为4。“公司信息”表中目前有42条记录。
  } catch (err) {
    console.log(err)
  }
}

//调用云函数返回含对应经纬度数据的“公司名称”列表。并按照markers属性样式生成markers列表
function getMarkersList3(companyShortNames) {
  var index2 = 0
  //console.log(companyShortNames)
  var markersList = []
  for (var index = 0; index < companyShortNames.data.length; index++) {
    if (companyShortNames.data[index].lat > 0) {
      markersList[index2] = {
        id: index2,
        latitude: companyShortNames.data[index].lat,
        longitude: companyShortNames.data[index].lng,
        // alpha:0,
        callout: {
          content: companyShortNames.data[index].short_name,
          padding: 10,
          display: 'ALWAYS',
          textAlign: 'center'
          // borderRadius: 10,
          // borderColor:'#ff0000',
          // borderWidth: 2,
        }
      }
      index2++
    }
  }
  console.log(markersList)
  return markersList
  //that.setData({
  //markers: markersList
  //})
}

//检查调用云函数返回的含对应经纬度数据的“公司名称”列表，将“纬度=0且经度=0”的数据的“_id”和“short_name”装入列表中返回
function cleanNotNullLatLng(companyShortNames) {
  var nullLatLngComapnyShortnames = []
  var index2 = 0
  for (var index = 0; index < companyShortNames.length; index++) {
    if (companyShortNames[index].lat == 0 && companyShortNames[index].lng == 0) {
      nullLatLngComapnyShortnames[index2] = {
        _id: companyShortNames[index]._id,
        short_name: companyShortNames[index].short_name
      }
      index2++
    }
  }
  console.log('准备查询地理坐标的“公司简称”列表已就绪')
  console.log(nullLatLngComapnyShortnames)
  return nullLatLngComapnyShortnames
}

//将“纬度=0且经度=0”的数据的“_id”和“short_name”装入列表后，通过腾讯地图的“qqmap-wx-jssdk”，循环列表，根据“公司名称”，查询对应的纬经度信息，
//将“_id”、“lat”和“lng”装入列表中返回
function prepareCompanyLatLng(companyShortNames, latLngList) {
  // 引入SDK核心类
  var QQMapWX = require('qqmap-wx-jssdk.js')
  // 实例化API核心类
  var qqmapsdk = new QQMapWX({
    key: 'HJ4BZ-FWKKP-UCQDO-LNPOL-RDYNS-DEFHH' // 必填
  })
  //var latLngList = []
  var index = 0
  var index2 = 0
  var index3 = 0
  //实测腾讯地图接口的每秒请求上限次数为4
  var queryTime = 280
  var setTimeoutCount = queryTime * companyShortNames.length
  console.log('根据准备查询地理坐标的“公司简称”列表长度，将总循环查询时长设置为' + setTimeoutCount / 1000 + 's')
  var timer = setInterval(function() {
    //res.data.status == '120' "此key每秒请求量已达到上限"，实测腾讯地图接口的每秒请求上限次数为4
    //res.data.status == '347' "查询无结果"
    //res.data.status == '306' "请求有互斥信息请检查字符串"
    qqmapsdk.geocoder({
      address: companyShortNames[index].short_name,
      success: function(res) {
        latLngList[index3] = {
          id: companyShortNames[index2]._id,
          lat: res.result.location.lat,
          lng: res.result.location.lng
        }
        //在异步函数中的回调方法success和fail中计数，以确定是哪一条companyShortName发起的查询成功获取到地理坐标，并将其_id和查询到的坐标值保存到结果集中
        index2++
        index3++
        console.log(res)
      },
      fail: function(res) {
        index2++
        console.log(res)
      }
    })
    index++
  }, queryTime)
  setTimeout(function() {
    clearInterval(timer)
    console.log('循环调用腾讯地图接口的周期设置已结束')
    console.log('准备更新地理坐标的“公司简称”的数据集已就绪')
    console.log(latLngList)
    //return latLngList
  }, setTimeoutCount)
}

//调用云函数，将含“_id”、“lat”和“lng”数据(原地理坐标为[0，0]，后成功查询到纬经度信息的“公司名称”)的列表更新到云数据库companies数据集的对应记录
function updateCompanyLatLng(companyShortNames) {
  for (var index = 0; index < companyShortNames.length; index++) {
    wx.cloud.callFunction({
      name: 'updateCompanyLatLng',
      data: {
        id: companyShortNames[index].id,
        lat: companyShortNames[index].lat,
        lng: companyShortNames[index].lng
      },
      success: function(res) {
        console.log(res)
      },
      fail: function(res) {
        console.log(res)
      }
    })
  }
}

//为便于手机展示地图效果，返回一个静态的基于“发货金额”的TOP10的客户名称的Markers
function getMarkersFromStaticTop10Customers() {
  var markers = [{
      id: 0,
      latitude: 26.807430,
      longitude: 102.050580,
      // alpha:0,
      callout: {
        content: '攀枝花市正源科技',
        padding: 10,
        display: 'ALWAYS',
        textAlign: 'center',
        // borderRadius: 10,
        // borderColor:'#ff0000',
        // borderWidth: 2,
      }
    },
    {
      id: 1,
      latitude: 26.579010,
      longitude: 101.726490,
      // alpha:0,
      callout: {
        content: '攀枝花汇钛科技',
        padding: 10,
        display: 'ALWAYS',
        textAlign: 'center',
        // borderRadius: 10,
        // borderColor:'#ff0000',
        // borderWidth: 2,
      }
    },
    {
      id: 2,
      latitude: 30.182030,
      longitude: 105.851852,
      // alpha:0,
      callout: {
        content: '重庆新华化工',
        padding: 10,
        display: 'ALWAYS',
        textAlign: 'center',
        // borderRadius: 10,
        // borderColor:'#ff0000',
        // borderWidth: 2,
      }
    },
    {
      id: 3,
      latitude: 31.300090,
      longitude: 121.513470,
      // alpha:0,
      callout: {
        content: '国本（上海 ）企业发展',
        padding: 10,
        display: 'ALWAYS',
        textAlign: 'center',
        // borderRadius: 10,
        // borderColor:'#ff0000',
        // borderWidth: 2,
      }
    },
    {
      id: 4,
      latitude: 31.344324,
      longitude: 121.449260,
      // alpha:0,
      callout: {
        content: '上海硕婴实业',
        padding: 10,
        display: 'ALWAYS',
        textAlign: 'center',
        // borderRadius: 10,
        // borderColor:'#ff0000',
        // borderWidth: 2,
      }
    },
    {
      id: 5,
      latitude: 31.527490,
      longitude: 120.465290,
      // alpha:0,
      callout: {
        content: '无锡华光新动力环保科技',
        padding: 10,
        display: 'ALWAYS',
        textAlign: 'center',
        // borderRadius: 10,
        // borderColor:'#ff0000',
        // borderWidth: 2,
      }
    },
    {
      id: 6,
      latitude: 32.173371,
      longitude: 119.703579,
      // alpha:0,
      callout: {
        content: '凯龙蓝烽新材料科技',
        padding: 10,
        display: 'ALWAYS',
        textAlign: 'center',
        // borderRadius: 10,
        // borderColor:'#ff0000',
        // borderWidth: 2,
      }
    },
    {
      id: 7,
      latitude: 37.675369,
      longitude: 115.061295,
      // alpha:0,
      callout: {
        content: '河北惠尔信新材料',
        padding: 10,
        display: 'ALWAYS',
        textAlign: 'center',
        // borderRadius: 10,
        // borderColor:'#ff0000',
        // borderWidth: 2,
      }
    },
    {
      id: 8,
      latitude: 34.357910,
      longitude: 108.933410,
      // alpha:0,
      callout: {
        content: '启源（西安）大荣环保科技',
        padding: 10,
        display: 'ALWAYS',
        textAlign: 'center',
        // borderRadius: 10,
        // borderColor:'#ff0000',
        // borderWidth: 2,
      }
    },
    {
      id: 9,
      latitude: 39.824246,
      longitude: 116.288816,
      // alpha:0,
      callout: {
        content: '北京涂多多电子商务',
        padding: 10,
        display: 'ALWAYS',
        textAlign: 'center',
        // borderRadius: 10,
        // borderColor:'#ff0000',
        // borderWidth: 2,
      }
    },
    {
      id: 10,
      latitude: 30.098996,
      longitude: 120.631884,
      // alpha:0,
      callout: {
        content: '浙江德创环保科技',
        padding: 10,
        display: 'ALWAYS',
        textAlign: 'center',
        // borderRadius: 10,
        // borderColor:'#ff0000',
        // borderWidth: 2,
      }
    }
  ]
  return markers
}

//通过setInterval与setTimeout实现对异步方法的控制
function holdPositionForResults(results, timer, cycleTime, endTime) {
  timer = setInterval(function() {
    //timeIndex++
    console.log('got the timer' + timer)
    if (results == null || results.length == 0) {
      console.log('the results is null')
      console.log('wait and check again by ' + cycleTime / 1000 + 's')
    } else {
      console.log('now the results length is' + results.length)

      clearInterval(timer)
    }
  }, cycleTime)
  setTimeout(function() {
    clearInterval(timer)
  }, endTime)
}

module.exports = {
  formatTime: formatTime,
  loadOpenId: loadOpenId,
  getFullTableDataFromODataService: getFullTableDataFromODataService,
  getFullTableDataFromODataService2: getFullTableDataFromODataService2,
  drawArc: drawArc,
  getLatitudeAndLongitudeByAddressFromTencentMapWebService: getLatitudeAndLongitudeByAddressFromTencentMapWebService,
  getMarkersFromStaticTop10Customers: getMarkersFromStaticTop10Customers,
  holdPositionForResults: holdPositionForResults,
  getFullTableDataFromODataService3: getFullTableDataFromODataService3,
  getMarkersList: getMarkersList,
  getMarkersList2: getMarkersList2,
  getMarkersList3: getMarkersList3,
  cleanNotNullLatLng: cleanNotNullLatLng,
  updateCompanyLatLng: updateCompanyLatLng,
  prepareCompanyLatLng: prepareCompanyLatLng
}