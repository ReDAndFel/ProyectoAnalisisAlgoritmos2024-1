from . import JsonService as js

def add_time(json_file_path, algorithm_name, value):
        js.modify_property(json_file_path, algorithm_name, value)