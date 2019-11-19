// pages/index/customer.js
//import regeneratorRuntime from '../../utils/regenerator-runtime/runtime.js'
var util = require('../../utils/util.js')
var openId = null
var nickName = null
var latLngList = []
//初始化云函数环境
wx.cloud.init()
Page({

  /**
   * 页面的初始数据
   */
  data: {
    latitude: 26.807430, //攀枝花市正源科技纬度
    longitude: 102.050580, //攀枝花市正源科技经度，此经纬度用于确定手机地图显示的中心点
    maphasMarkers: false,
    //markers: util.getMarkersFromStaticTop10Customers(), //静态添加markers
    //markers: [],

    mapWidth: '',
    mapHeight: ''
  },
  toaddress: function(e) {
    console.log(e)
    var id = e.markerId
    console.log(id)
    // wx.openLocation({
    //   latitude: this.data.markers[id].latitude,
    //   longitude: this.data.markers[id].longitude,
    // })
    wx.navigateTo({
      url: '/pages/index/product',
      success: function(res) {},
      fail: function(res) {},
      complete: function(res) {},
    })
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function(options) {
    var sy = wx.getSystemInfoSync(),
      mapWidth = sy.windowWidth * 2,
      mapHeight = sy.windowHeight * 2;
    //util.getMarkersList(results, 'companies', nickName, markersList)
    this.setData({
      mapWidth: mapWidth,
      mapHeight: mapHeight,
      //markers: util.getMarkersFromStaticTop10Customers()
      //markers: util.getMarkersList(results, 'companies', nickName, markersList)
      //maphasMarkers: true
    })
    //此处已成功实现动态加载地图上的markers
    //var that = this
    //util.getMarkersList(results, 'companies', nickName, markersList, that)



    var that = this
    //var latLngList = null
    wx.cloud.callFunction({
      name: 'getCompanyShortNames',
      data: {
        a: 0,
        b: 1,
        c: 2
      },
      success: function(res) {
        //console.log(res)
        console.log(res.result.companyShortNames.data)

        //await util.getMarkersList2(res.result.companyShortNames.data, markersList, that)

        //此处已成功实现先检测云端数据库“客户简称”中地理坐标为空者，在腾讯地图WebService中查询地理坐标，成功查询的保存至云端数据库“客户简称”
        /**
        var companyShortNames = util.cleanNotNullLatLng(res.result.companyShortNames.data)
        util.prepareCompanyLatLng(companyShortNames, latLngList)
        setTimeout(function() {
          console.log(latLngList)
          util.updateCompanyLatLng(latLngList)
        }, 15000)
        */

        //console.log('latLngList'+latLngList.length)
        //return latLngList

        //此处已成功实现动态加载地图上的markers
        that.setData({
          markers: util.getMarkersList3(res.result.companyShortNames)
        })
      },
      fail: function(res) {
        console.log(res)
      }
    })

    /** 
    wx.cloud.callFunction({
      name: 'updateCompanyLatLng',
      data: {
        id: "1",
        lat: 0.1,
        lng: 0.2
      },
      success: function(res) {
        console.log(res)
      },
      fail: function(res) {
        console.log(res)
      }
    })
    */

    /** 
    wx.cloud.callFunction({
      name: 'getLatLngByAddressFromTencentMapWebService',
      data: {
        address: '攀枝花市正源科技',
        developerKey: 'HJ4BZ-FWKKP-UCQDO-LNPOL-RDYNS-DEFHH'
      },
      success: function(res) {
        //console.log(res.result.results.data)
        console.log(res)
      },
      fail: function(res) {
        console.log(res)
      }
    })
    */

    /**-// 引入SDK核心类
    var QQMapWX = require('../../utils/qqmap-wx-jssdk.js')
    // 实例化API核心类
    var qqmapsdk = new QQMapWX({
      key: 'HJ4BZ-FWKKP-UCQDO-LNPOL-RDYNS-DEFHH' // 必填
    })
    qqmapsdk.geocoder({
      address: '攀枝花市正源科技',
      success: function(res) {
        console.log(res)

      },
      fail: function(res) {
        console.log(res)
      }
    })-**/

    //var getMakersList = new Promise(function(resolve, reject) 
    util.loadOpenId(openId, nickName)
    //results = util.getFullTableDataFromODataService2('companies', nickName)
    /*--
    var i=setInterval(function() {
      timeIndex++
      console.log('got the timer'+timeIndex)
      if (results == null || results.length == 0)
      {
        console.log('the results is null')
        console.log('wait and check again by 0.2s')
      }
      else
      {
        clearInterval(i)
      }
    }, 200)
    setTimeout(function () { clearInterval(i) }, 3000)
    --*/
    //var timer
    //util.holdPositionForResults(results, timer, 100, 3000)

    //util.getFullTableDataFromODataService3('companies',nickName).then(function onFulfilled(value){
    //console.log('this is promise'+value.length)
    //}).catch(function onRejected(value){
    //console.log('this is promise+'+value)
    //})

    //console.log('the results length are' + results.length)


  },

  /**
   * 生命周期函数--监听页面初次渲染完成
   */
  onReady: function() {

  },

  /**
   * 生命周期函数--监听页面显示
   */
  onShow: function() {

  },

  /**
   * 生命周期函数--监听页面隐藏
   */
  onHide: function() {

  },

  /**
   * 生命周期函数--监听页面卸载
   */
  onUnload: function() {

  },

  /**
   * 页面相关事件处理函数--监听用户下拉动作
   */
  onPullDownRefresh: function() {

  },

  /**
   * 页面上拉触底事件的处理函数
   */
  onReachBottom: function() {

  },

  /**
   * 用户点击右上角分享
   */
  onShareAppMessage: function() {

  }
})