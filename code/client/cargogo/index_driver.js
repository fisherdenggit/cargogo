// index_driver.js
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
    var truckID=e.detail.value["inputTruckID"]
    var phone=e.detail.value["inputPhone"]
    var fName = e.detail.value["inputFName"]
    console.log(truckID+"/"+phone+"/"+fName)
    var that=this
    wx.request({
      //url: 'http://localhost:57499/odata/trucks',
      url: 'http://localhost:57499/odata/trucks(\''+truckID+'\')', 
      //method:'POST',//增
      //method:'DELETE',//删
      method:'GET',//查
      //method:'PUT',//改
      header: { 'content-type': 'application/json' },
      data: {
        //FromODataUri: truckID,
        //Truck:{
           TruckID:truckID,
           TruckType:'car',
           Driver1Name:fName,
           Driver1MPhone:phone
         //}
      },
      success:function(res)
      {
        that.setData(
          { 
            returnPhone: res.data["Driver1MPhone"],
            returnName: res.data["Driver1Name"]
          }
        )
        console.log(res)
        console.log(res.data["Driver1MPhone"])
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
})