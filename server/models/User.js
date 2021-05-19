const mongoose = require("mongoose")
const Schema = mongoose.Schema

const UserSchema = new Schema({
  firstName: {
    type: String,
    required: true,
  },
  lastName: {
    type: String,
    required: true,
  },
  gender: {
    type: String,
    required: true,
    immutable: true,
  },
  email: {
    type: String,
    required: true,
    immutable: true,
  },
  password: {
    type: String,
    required: true,
  },
  createdAt: {
    type: Date,
    default: Date.now,
    immutable: true,
  },
})

module.exports = User = mongoose.model("users", UserSchema)
