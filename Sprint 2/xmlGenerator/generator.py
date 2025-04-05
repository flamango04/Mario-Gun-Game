import pandas as pd
import xml.etree.ElementTree as ET

# Load the Excel file
file_path = './data/level-1完整版.xlsx'
df = pd.read_excel(file_path, sheet_name='Sheet1')

# Function to convert location formulas into numeric values
def convert_location_formula(formula):
    try:
        # For now, we'll just interpret the simple ones like "16*0" or "480-(16*2)"
        if '*' in formula:
            return eval(formula.replace('(', '').replace(')', ''))
        return formula
    except Exception as e:
        return '0'

# Function to prettify the XML with indentation
def prettify(elem):
    from xml.dom import minidom
    rough_string = ET.tostring(elem, encoding="utf-8", method="xml")
    reparsed = minidom.parseString(rough_string)
    return reparsed.toprettyxml(indent="  ")

# Clean the data and convert it to XML with indentation
root = ET.Element("XnaContent")
asset = ET.SubElement(root, "Asset", Type="MyDataTypes.LevelObjectData[]")

for _, row in df.iterrows():
    if pd.notna(row['Type']) and pd.notna(row['Name']):
        item = ET.SubElement(asset, "Item")
        ET.SubElement(item, "ObjectType").text = row['Type']
        ET.SubElement(item, "ObjectName").text = row['Name']
        
        # Process location X and Y
        loc_x = convert_location_formula(str(row['LocationX']))
        loc_y = convert_location_formula(str(row['LocationY']))
        ET.SubElement(item, "Location").text = f"{loc_x} {loc_y}"

# Prettify the XML structure
pretty_xml_str = prettify(root)

# Save the prettified XML to a file
output_file_pretty_path = "./data/level-1_data_pretty.xml"
with open(output_file_pretty_path, "w", encoding="utf-8") as f:
    f.write('<?xml version="1.0" encoding="utf-8" ?>\n' + pretty_xml_str)

print("XML file saved to:", output_file_pretty_path)