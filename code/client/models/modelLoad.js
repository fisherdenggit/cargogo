//modelLoad.js
var openId = null
var nickName = null
var result = null //['', '', '', '', '']
var results = new Array()
var recordPosition = 0
var tableId = 0
var util = require('../utils/util.js')
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
    tables: [{
        id: 0,
        name: '银行账户',
        labels: ['ID', '公司代码', '开户银行', '银行账号', '币种代码', '备注信息']
      },
      {
        id: 1,
        name: '公司信息',
        labels: ['ID', '公司代码', '公司简称', '公司全称', '商业类型代码', '电话', '传真', '网址', '注册地址', '公司税号', '采购部/销售部联系人地址', '采购部/销售部联系人', '采购部/销售部联系人手机', '采购部/销售部联系人邮箱', '财务部联系人地址', '财务部联系人', '财务部联系人手机', '财务部联系人邮箱', '发货金额总计', '付款金额总计', '余款/欠款总计', '未开票金额总计', '币种']
      },
      {
        id: 2,
        name: '收货地址',
        labels: ['ID', '公司代码', '收货地址', '收货人员', '联系方式']
      },
      {
        id: 3,
        name: '合同信息',
        labels: ['ID', '合同编号', '合同日期', '公司代码', '产品代码', '合同数量', '合同价格', '合同已执行数量', '备注']
      },
      {
        id: 4,
        name: '收支方向',
        labels: ['ID', '方向代码', '方向名称']
      },
      {
        id: 5,
        name: '发票信息',
        labels: ['ID', '发票号码', '开票日期', '发票金额', '方向代码', '公司代码', '备注']
      },
      {
        id: 6,
        name: '付款类型',
        labels: ['ID', '类型代码', '类型名称']
      },
      {
        id: 7,
        name: '付款明细',
        labels: ['ID', '付款日期', '收支方向代码', '公司代码', '付款类型代码', '付款金额', '备注']
      },
      {
        id: 8,
        name: '产品名称',
        labels: ['ID', '产品代码', '产品名称', '备注']
      }
    ]
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function(options) {
    util.loadOpenId(openId, nickName)
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
    //wx.navigateTo({
    //url: 'pages/index/index',
    //})
  },

  onInputConfirm: function(e) {
    //inputValue:'hahahha'
    //this.setData
  },

  onSubmit: function(e) {
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

  changeText: function() {
    // this.data.text = 'changed data' // bad, it can not work 
    this.setData({
      texts: 'fuck u'
    })
  },
  changeItemInArray: function() {
    // you can use this way to modify a danamic data path 
    this.setData({
      'array[0].text': 'changed data'
    })
  },
  changeItemInObject: function() {
    this.setData({
      'object.texts': 'changed??? data'
    });
  },
  addNewField: function() {
    this.setData({
      'newField': 'new data',
      'newButton.text': 'new data----------'
    })
  },

  //选择对应的基础数据表
  bindPickerChange: function(e) {
    //var that=this
    console.log('picker发送选择改变，携带值为', e.detail.value)
    //result=tables[index].texts
    this.setData({
      index: e.detail.value,
      result: []
    })
    tableId = e.detail.value
    results = []
    recordPosition = 0
    //console.log(tables[counter].labels)
    //util.getFullTableDataFromODataService('bankaccouts', nickName,result,results,recordPosition,that)
  },

  //下一条记录
  bindNextRecord: function(e) {
    if (recordPosition < results.length - 1) {
      recordPosition++
    }
    if (result == null) {
      var that = this
      if (tableId == 0) {
        util.getFullTableDataFromODataService('bankaccouts', nickName, result, results, recordPosition, that)
      }
      if (tableId == 1) {
        util.getFullTableDataFromODataService('companies', nickName, result, results, recordPosition, that)
      }
      if (tableId == 2) {
        util.getFullTableDataFromODataService('companydeliveryaddresses', nickName, result, results, recordPosition, that)
      }
      if (tableId == 3) {
        util.getFullTableDataFromODataService('contracts', nickName, result, results, recordPosition, that)
      }
      if (tableId == 4) {
        util.getFullTableDataFromODataService('directions', nickName, result, results, recordPosition, that)
      }
      if (tableId == 5) {
        util.getFullTableDataFromODataService('invoices', nickName, result, results, recordPosition, that)
      }
      if (tableId == 6) {
        util.getFullTableDataFromODataService('paymenttypes', nickName, result, results, recordPosition, that)
      }
      if (tableId == 7) {
        util.getFullTableDataFromODataService('payments', nickName, result, results, recordPosition, that)
      }
      if (tableId == 8) {
        util.getFullTableDataFromODataService('products', nickName, result, results, recordPosition, that)
      }
    }
    console.log('recordPosition is' + recordPosition)
    this.setData({
      result: results[recordPosition]
    })
  },

  //上一条记录
  bindLastRecord: function(e) {
    if (recordPosition > 0) {
      recordPosition--
    } else {
      if (result == null) {
        var that = this
        if (tableId == 0) {
          util.getFullTableDataFromODataService('bankaccouts', nickName, result, results, recordPosition, that)
        }
        if (tableId == 1) {
          util.getFullTableDataFromODataService('companies', nickName, result, results, recordPosition, that)
        }
        if (tableId == 2) {
          util.getFullTableDataFromODataService('companydeliveryaddresses', nickName, result, results, recordPosition, that)
        }
        if (tableId == 3) {
          util.getFullTableDataFromODataService('contracts', nickName, result, results, recordPosition, that)
        }
        if (tableId == 4) {
          util.getFullTableDataFromODataService('directions', nickName, result, results, recordPosition, that)
        }
        if (tableId == 5) {
          util.getFullTableDataFromODataService('invoices', nickName, result, results, recordPosition, that)
        }
        if (tableId == 6) {
          util.getFullTableDataFromODataService('paymenttypes', nickName, result, results, recordPosition, that)
        }
        if (tableId == 7) {
          util.getFullTableDataFromODataService('payments', nickName, result, results, recordPosition, that)
        }
        if (tableId == 8) {
          util.getFullTableDataFromODataService('products', nickName, result, results, recordPosition, that)
        }
      }
    }
    console.log('recordPosition is' + recordPosition)
    this.setData({
      result: results[recordPosition]
    })
    //选择“公司信息”基础表时，绘制N元统计饼图
    if (tableId == 1) {
      var invoicedAmount = parseFloat(results[recordPosition][18]) - parseFloat(results[recordPosition][21]) //此处“已发货金额”和“未开发票金额”要先转换成数字类型，否则可能会出现字符串类型参与之后的计算而引发错误
      invoicedAmount = parseFloat(invoicedAmount.toFixed(2))
      var uninvoicedAmount = parseFloat(results[recordPosition][21]) //此处“未开发票金额”要先转换成数字类型，否则可能会出现字符串类型参与之后的计算而引发错误
      uninvoicedAmount = parseFloat(uninvoicedAmount.toFixed(2))
      var datas = [invoicedAmount, uninvoicedAmount]
      console.log(datas)
      //console.log(datas[0]+datas[1])
      //console.log(results[recordPosition][18])
      var labels = ['已开发票金额(元)', '未开发票金额(元)']
      var colors = ['green', 'orange']
      util.drawArc('canvasInvoicedAmount', 61, 100, 60, datas, colors, labels)
      labels = ['已付款金额(元)', '欠款金额(元)']
      var payedAmount = parseFloat(results[recordPosition][19]) //此处“已付款金额”要先转换成数字类型，否则可能会出现字符串类型参与之后的计算而引发错误
      var unPayedAmount = parseFloat(results[recordPosition][18]) - payedAmount
      payedAmount = parseFloat(payedAmount.toFixed(2))
      unPayedAmount = parseFloat(unPayedAmount.toFixed(2))
      if (unPayedAmount < 0) {
        unPayedAmount = 0 - unPayedAmount
        labels[1] = '预付款金额'
        colors[1] = 'blue'
      }
      datas = [payedAmount, unPayedAmount]
      util.drawArc('canvasPayedAmount', 61, 100, 60, datas, colors, labels)
    }
  }
})