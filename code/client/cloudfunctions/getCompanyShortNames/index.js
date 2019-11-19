// 云函数入口文件
const cloud = require('wx-server-sdk')

cloud.init()
const db = cloud.database() //此处是方法而不是属性，这个()相当重要

// 云函数入口函数
exports.main = async(event, context) => {
  const wxContext = cloud.getWXContext()

  const companyShortNames = await db.collection('companies')
    //.where({
    //price: _.gt(10)
    //})
    .field({
      short_name: true,
      lat: true,
      lng: true
    })
    //.orderBy('short_name', 'asc') //desc 不指定则默认为asc排序
    //.skip(1)
    //.limit(100)
    .get()

  return {
    event,
    openid: wxContext.OPENID,
    appid: wxContext.APPID,
    unionid: wxContext.UNIONID,
    companyShortNames: companyShortNames
  }
}