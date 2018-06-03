//model_load.js
var openID=null
var loginCode=null
Page({

  /**
   * 页面的初始数据
   */
  data: {
    //inputValue:''
    //buttonType:'primary'
    //this.setData
    //texts: 'init01 data',
    //array: [{ text: 'init02 data' }],
    //object: {
      //texts: 'init03 data'
    //},
    //inputTester:"点我啊" 
    tables: [
      {id:0,name:'银行账户',labels:['公司代码','开户银行','银行账号']}, 
      {id:1,name:'公司信息'}, 
      {id:2,name:'收货地址'}, 
      {id:3,name:'合同信息'}
      ]
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
    //wx.navigateTo({
      //url: 'pages/index/index',
    //})
  },

  onInputConfirm:function(e){
    //inputValue:'hahahha'
    //this.setData
  },

  onSubmit:function(e){
    /*var formData=e.detail.value
    if(formData.truckID!="")
    {
      wx.setStorage({
        key: '1',
        data: formData.truckID.toString(),
      })
    }*/
    //var formData = e.detail.value
    //console.log(e.detail.value["inputTruckID"])
    /*
    this.setData({
      inputTester:e.detail.value["inputTruckID"]
    })

    wx.checkSession({
      success: function (res) {
        console.log("wx.checkSession()成功")
        console.log("this is openId: "+openID)
        if(openID==null)
        {
          wx.login({
            success: function (res) {
              console.log("wx.login()成功在session非空")
              loginCode = res.code
              console.log("this is loignSuccess.code在session非空: " + loginCode)
            },
            fail: function (res) {
              console.log("wx.login()失败在session非空")
            }
          })

          wx.request({
            url: 'https://api.weixin.qq.com/sns/jscode2session?appid=wx7e6c11974fbb3699&secret=a2af134685148f465721879f6ceab094&js_code=' + loginCode + '&grant_type=authorization_code',
            success: function (res) {
              console.log("this is sessionKey在session非空: " + res.data["session_key"])
              openID = res.data.openid
              console.log("this is openId在session非空: " + openID)
            },
            fail: function (res) {
              console.log("换取登录令牌失败")
            }
          })
        }
      },
      fail: function (res) {
        console.log("wx.checkSession()失败")
        wx.login({
          success: function (res) {
            console.log("wx.login()成功")
            loginCode = res.code
            console.log("this is loignSuccess.code: " + loginCode)
          },
          fail: function (res) {
            console.log("wx.login()失败")
          }
        })

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
      }
    })

    
    
    

    console.log(wx.getUserInfo({
      success: function (res) {
        var userInfo = res.userInfo
        var nickName = userInfo.nickName
        var avatarUrl = userInfo.avatarUrl
        var gender = userInfo.gender //性别 0：未知、1：男、2：女
        var province = userInfo.province
        var city = userInfo.city
        var country = userInfo.country
        console.log(userInfo)
        console.log(nickName)
      }
    })
    )

    var that=this
    wx.request({
      url: 'http://localhost:57499/odata/trucks',
      //url:"https://www.tencent.com",
      success: function (res) {
        that.setData(
        {
          //var d=JSON.parse(res.data)
          inputTester:res.data["value"][0].TruckID
        
        })
        console.log(res.data)
        console.log(res.data["value"])
        console.log(res.data["value"][0])
        console.log(res.data["value"][0].TruckID)
        console.log("this is openId: " + openID)//用以显示第一次登录未有session时的状态
      }
    })
    */
    
    
    //buttonType ="primary"
    //this.setData
  },

  changeText: function () {
    // this.data.text = 'changed data' // bad, it can not work 
    this.setData({
      texts: 'fuck u'
    })
  },
  changeItemInArray: function () {
    // you can use this way to modify a danamic data path 
    this.setData({
      'array[0].text': 'changed data'
    })
  },
  changeItemInObject: function () {
    this.setData({
      'object.texts': 'changed??? data'
    });
  },
  addNewField: function () {
    this.setData({
      'newField': 'new data',
      'newButton.text':'new data----------'
    })
  }, 

  bindPickerChange: function (e) {
    console.log('picker发送选择改变，携带值为', e.detail.value)
    this.setData({
      index: e.detail.value
    })
  }
})