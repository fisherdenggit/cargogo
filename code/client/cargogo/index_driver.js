// index_driver.js
var openID=null
var nickName=null
Page({

  /**
   * 页面的初始数据
   */
  data: {
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {
  
  },

  /**
   * 生命周期函数--监听页面初次渲染完成
   */
  onReady: function () {
  
  },

  /**
   * 生命周期函数--监听页面显示
   */
  onShow: function () {
  
  },

  /**
   * 生命周期函数--监听页面隐藏
   */
  onHide: function () {
  
  },

  /**
   * 生命周期函数--监听页面卸载
   */
  onUnload: function () {
  
  },

  /**
   * 页面相关事件处理函数--监听用户下拉动作
   */
  onPullDownRefresh: function () {
  
  },

  /**
   * 页面上拉触底事件的处理函数
   */
  onReachBottom: function () {
  
  },

  /**
   * 用户点击右上角分享
   */
  onShareAppMessage: function () {
  
  },

  /**获取提交表单里的数据 */
  onSubmit:function(e)
  {
    if(openID==null)
    {
      var loginCode
      /*第一次调用wx.login()，以获取openId和nickName*/
      wx.login({
        success:function(res){
          /*以下为向微信小程序登录服务器换取登录令牌*/
          loginCode=res.code
          wx.request({
            url: 'https://api.weixin.qq.com/sns/jscode2session?appid=wx7e6c11974fbb3699&secret=a2af134685148f465721879f6ceab094&js_code=' + loginCode + '&grant_type=authorization_code',
            success: function (res) {
              console.log("this is sessionKey: " + res.data["session_key"])
              openID = res.data.openid
              console.log("this is openId: " + openID)
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
              console.log("this is the nickName: " + nickName)
            }
          })
          /*以上为用openId通过wx.getUserInfo()的不经用户授权方式获取用户信息中的nickName*/
        }
      })
      
      
      
      /*wx.chooseAddress({
        success: function (res) {
          console.log(res.userName)
          console.log(res.postalCode)
          console.log(res.provinceName)
          console.log(res.cityName)
          console.log(res.countyName)
          console.log(res.detailInfo)
          console.log(res.nationalCode)
          console.log(res.telNumber)
        }
      })*/
    }
    /*第二次调用wx.login()，以获取新的loginCode,并与nickName作为参数一道通过wx.request()传递给第3方服务器*/
    wx.login({
      success: function (res) {
        console.log('loginCode is:' + res.code)
        loginCode = res.code
        console.log(loginCode)
        console.log('http://localhost:57499/odata/trucks(\'' + truckID + '\')?loginCode=' + loginCode)

        wx.request({
          //url: 'http://localhost:57499/odata/trucks',
          url: 'http://localhost:57499/odata/trucks(\'' + truckID + '\')?loginCode=' + loginCode + '&nickName=' + nickName,
          //method:'POST',//增
          //method:'DELETE',//删
          method: 'GET',//查，默认方法
          //method: 'PUT',//改
          header: { 'content-type': 'application/json' },
          data: {
            //FromODataUri: truckID,
            //Truck:{
            TruckID: truckID,
            TruckType: 'car',
            Driver1Name: fName,
            Driver1MPhone: phone
            //}
          },
          success: function (res) {
            // method:'GET',//查,将查询返回结果的值绑定到页面显示
            that.setData(
              {
                returnPhone: res.data["Driver1MPhone"],
                returnName: res.data["Driver1Name"]
              }
            )
            console.log(res)
            //console.log()
            //console.log(res.data["Driver1MPhone"])
          }
        })
      }
    })

    console.log(loginCode)
    var truckID = e.detail.value["inputTruckID"]
    var phone = e.detail.value["inputPhone"]
    var fName = e.detail.value["inputFName"]
    console.log(truckID + "/" + phone + "/" + fName)
    var that = this
    console.log('http://localhost:57499/odata/trucks(\'' + truckID + '\')?loginCode=' + loginCode)
  }
})