import services.JsonService as js
import matplotlib.pyplot as plt
import numpy as np

json_times_file_path = "times8.json"
data = js.read_json(json_times_file_path)

labels = list(data['cs'].keys())
cs_values = list(data['cs'].values())
py_values = list(data['py'].values())

# Asegurarse de que todas las listas tengan el mismo tamaño
min_length = min(len(labels), len(cs_values), len(py_values))
labels = labels[:min_length]
cs_values = cs_values[:min_length]
py_values = py_values[:min_length]

fig, ax = plt.subplots(figsize=(12, 6))

x = np.arange(len(labels))
width = 0.4

ax.bar(x - width/2, cs_values, width, label='C#')
ax.bar(x + width/2, py_values, width, label='Python')

ax.set_xlabel('Algoritmo')
ax.set_ylabel('Tiempo')
ax.set_title('Comparación de tiempos entre C# y Python')
ax.set_xticks(x)
ax.set_xticklabels(labels, rotation=90)
ax.legend()

plt.tight_layout()
plt.show()