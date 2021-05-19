require("dotenv").config()
const express = require("express")
const bodyParser = require("body-parser")
// const passport = require("passport")
const cors = require("cors")

const connectDb = require("./db/connection")

const app = express()

app.use(bodyParser.urlencoded({ extended: false }))
app.use(bodyParser.json())
app.use(cors({ credentials: true, origin: true }))
app.options("*", cors())

connectDb()
  .then(() => {
    console.log("Connected to MongoDB")
  })
  .catch((error) => console.error(error))

const port = process.env.PORT || 3010
app.listen(port, () => console.log("server is running"))
