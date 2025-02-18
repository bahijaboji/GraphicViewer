# **GraphicViewer**

## **Overview**
GraphicViewer is a **WPF-based vector graphic viewer** that loads and renders geometric shapes from a JSON file.
It supports **lines, circles, and triangles** and is designed to be easily extensible for additional shapes and file formats.

---

## **Installation & Setup**
### **1. Clone the Repository**
```sh
git clone https://github.com/yourusername/GraphicViewer.git
cd GraphicViewer
```

### **2. Open in Visual Studio**
- Open `GraphicViewer.sln` in **Visual Studio**
- Ensure you have `.NET 6+` installed

### **3. Run the Application**
- Build and run the project in **Visual Studio** (`F5` or `Ctrl + F5`)
- Click the **"Load JSON"** button and select a valid JSON file

---

## **Usage**
1. **Click "Load JSON"** to select a file.
2. The application parses the JSON and displays the shapes.
3. The canvas auto-scales the shapes to fit the window.
4. Shapes are colorized based on the **ARGB format** from the JSON file.

### **Example JSON Input**
[
 {
 "type": "line",
 "a": "-1,5; 3,4",
 "b": "2,2; 5,7",
 "color": "127; 255; 255; 255"
 },
 {
 "type": "circle",
 "center": "0; 0",
 "radius": 15.0,
 "filled": false,
 "color": "127; 255; 0; 0"
 },
 {
 "type": "triangle",
 "a": "-15; -20",
 "b": "15; -20,3",
 "c": "0; 21",
 "filled": true,
 "color": "127; 255; 0; 255"
 }
]

