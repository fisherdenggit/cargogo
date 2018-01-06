//app.js
App({
  onLaunch: function() {
    //调用API从本地缓存中获取数据
    var logs = wx.getStorageSync('logs') || []
    logs.unshift(Date.now())
    wx.setStorageSync('logs', logs)
    wx.login({
      success:res=>{
      }
    })
    /*wx.login({
      success: function (res) {
        console.log(res.code)
        var js_code = res.code
        wx.request({
          url: 'https://api.weixin.qq.com/sns/jscode2session?appid=wx7e6c11974fbb3699&secret=a2af134685148f465721879f6ceab094&' + js_code + '=JSCODE&grant_type=authorization_code',
          success: function (res) {
            console.log(res.data["session_key"])
          },
          fail: function (res) {
            console.log("换取登录令牌失败")
          }
        })
      }
    })*/
  },

  getUserInfo: function(cb) {
    var that = this
    if (this.globalData.userInfo) {
      typeof cb == "function" && cb(this.globalData.userInfo)
    } else {
      //调用登录接口
      wx.getUserInfo({
        withCredentials: false,
        success: function(res) {
          that.globalData.userInfo = res.userInfo
          typeof cb == "function" && cb(that.globalData.userInfo)
        }
      })
    }
  },

  globalData: {
    userInfo: null
  }
})
