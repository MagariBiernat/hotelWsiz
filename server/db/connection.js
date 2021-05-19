require("dotenv").config()
const mongoose = require("mongoose")

const URI = process.env.dbUrl

const connectDb = async () => {
  await mongoose.connect(URI, {
    useNewUrlParser: true,
    useUnifiedTopology: true,
  })
}

module.exports = connectDb
