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
function loadOpenId(openId,nickName){
  if (openId == null) {
    var loginCode
    /*第一次调用wx.login()，以获取openId和nickName*/
    wx.login({
      success: function (res) {
        /*以下为向微信小程序登录服务器换取登录令牌*/
        loginCode = res.code
        wx.request({
          url: 'https://api.weixin.qq.com/sns/jscode2session?appid=wx7e6c11974fbb3699&secret=a2af134685148f465721879f6ceab094&js_code=' + loginCode + '&grant_type=authorization_code',
          success: function (res) {
            console.log("this is sessionKey: " + res.data["session_key"])
            openId = res.data.openid
            console.log("this is openId: " + openId)
          },
          fail: function (res) {
            console.log("换取登录令牌失败")
          }
        })
        /*以上为向微信小程序登录服务器换取登录令牌*/

        /*以下为用openId通过wx.getUserInfo()的不经用户授权方式获取用户信息中的nickName*/
        //var nickName
        wx.getUserInfo({
          openIdList: ['selfOpenId'],
          lang: 'zh_CN',
          success: function (res) {
            nickName = res.userInfo.nickName
            console.log('this is the nickName: ' + nickName)
          }
        })
        /*以上为用openId通过wx.getUserInfo()的不经用户授权方式获取用户信息中的nickName*/
      }
    })
  }
}

function getFullTableDataFromODataService(serviceName,nickName,result,results,recordPosition,that){
  if (results.length == 0) 
  {
    wx.login({
      success:function(res)
      {
        //微信的login方法返回“成功”时获取为第三方服务器ODataService准备的loginCode
        var loginCode=res.code
        console.log('this is loginCode for ODataService:'+loginCode)
        //从微信小程序端向第三方服务器的ODataService发起HTTP的REQUEST请求
        console.log(results.length)
        //if (results.length==0){
          //serviceName+='(\''+recordIds[recordPosition]+'\')'
          wx.request
          (
            {
                url: 'http://localhost:57499/odata/' + serviceName + '?loginCode=' + loginCode + '&nickName=' + nickName,
                method: 'GET',
                success: function (res) 
                {
                  console.log(res)
                  console.log(res.data.value[0].CompanyCode)
                  console.log(res.data.value.length)//非常重要，这里返回了成功返回的记录条数
                  //recordPosition=0
                  //result=res.data.value[0].CompanyCode
                  //results = new Array()
                  for (var index = 0; index < res.data.value.length; index++) 
                  {
                    var tempResult = [res.data.value[index].CompanyCode, res.data.value[index].BankName, res.data.value[index].BankAccount, res.data.value[index].CurrencyCode, res.data.value[index].Note]
                    results[index] = tempResult
                  }
                  that.setData({
                    recordPosition: 0,
                    result: results[recordPosition]
                    //recordIds:res.data.value.count,
                  })
                }
            }
          )
        //}  
      }
    })
  }
}

module.exports = {
  formatTime: formatTime,
  loadOpenId:loadOpenId,
  getFullTableDataFromODataService
}
