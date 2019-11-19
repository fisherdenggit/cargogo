// 云函数入口文件
const cloud = require('wx-server-sdk')
const request = require('request')
const rp = require('request-promise')
//const soap = require('soap')

cloud.init()

// 云函数入口函数
exports.main = async (event, context) => {
  const wxContext = cloud.getWXContext()

  var latitudeAndLongitude = null

  //request.get()
  var options = {
    uri: 'https://apis.map.qq.com/ws/geocoder/v1/?address=' + event.address + '&key=' + event.developerKey,
    method: 'GET',
    json: true
  }
  latitudeAndLongitude = await rp(options).then(function (res) {
    return res
  }).catch(function (err) {
    return err
  })

  /**
   * latitudeAndLongitude = new Promise(function(resolve, reject) {
    try {
      request({url:'https://apis.map.qq.com/ws/geocoder/v1/?address=' + event.address + '&key=' + event.developerKey,
      sucess:function(res){
        return resolve(res)
      },
      fail:function(res){
        return reject(res)
      }
      })
    } catch (err) {
      return reject(err)
    }
  })**/

  return {
    event,
    openid: wxContext.OPENID,
    appid: wxContext.APPID,
    unionid: wxContext.UNIONID,
    latitudeAndLongitude: latitudeAndLongitude
  }
}