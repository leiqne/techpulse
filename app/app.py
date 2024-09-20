from flask import Flask
from pathlib import Path

def create_app():
    static_folder = Path(__file__).parent / 'static'
    app = Flask(__name__, static_folder=static_folder)

    from app.routes.public import public_routes

    # Registrar rutas
    app.register_blueprint(public_routes)

    return app