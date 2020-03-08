import os

from PIL import Image

from tabulate import tabulate


MODE_TO_DEPTH = {'1': 1, 'L': 8, 'P': 8, 'RGB': 24, 'RGBA': 32, 'CMYK': 32, \
    'YCbCr': 24, 'I': 32, 'F': 32}


def get_image_info(image_path):
    image = Image.open(image_path)
    image.load()    

    width, height = image.size

    return {
        'image_name': os.path.basename(image_path), 
        'width': width,
        'height': height,
        'dpi': image.info.get('dpi', 'Unknown'),
        'color_depth': MODE_TO_DEPTH.get(image.mode, 'Unknown'),
        'compression': image.info.get('compression', 'Unknown'),
    }


if __name__ == "__main__":

    abs_path = input('Enter absolute path to the directory with images: ')
    if abs_path.startswith('"'):
        abs_path = abs_path[1:]
    if abs_path.endswith('"'):
        abs_path = abs_path[:-1]

    images_info = [get_image_info(image_entry.path) for image_entry in os.scandir(abs_path)]
    print(tabulate([image_info.values() for image_info in images_info], \
        headers=['name', 'width', 'height', 'dpi', 'color_depth', 'compression']))
