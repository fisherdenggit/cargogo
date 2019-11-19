// 云函数入口文件
const cloud = require('wx-server-sdk')

cloud.init()
const db = cloud.database() //此处是方法而不是属性，这个()相当重要

// 云函数入口函数
exports.main = async(event, context) => {
  const wxContext = cloud.getWXContext()

  //try {
  const updateLatLng = await db.collection('companies').doc(event.id).update({
    data: {
      lat: event.lat,
      lng: event.lng
    }
  })
  //} catch (err) {
  //console.log(err)
  //}

  return {
    event,
    openid: wxContext.OPENID,
    appid: wxContext.APPID,
    unionid: wxContext.UNIONID,
    updateLatLng: updateLatLng
  }
}