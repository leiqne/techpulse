from flask import Blueprint, render_template, request, jsonify

route = Blueprint('public_routes', __name__, template_folder='./templates')

@route.get("/")
def index():
    return render_template("index.html")

@route.get("/login")
def login():
    return render_template("login.html")
@route.get("/register")
def register():
    return render_template("register.html")
@route.get("/application")
def application():
   return render_template("app.html")