from collections import deque


def bsf_Task(graph, start, end):
    queue = deque([[start]]) #kolekcjia do przechowywania sciezek
    visited = set() #wierzchołki odwiedzone

    while queue:
        path = queue.popleft()
        node = path[-1] #ostatni wierzchołek w ścieżce
        #je seli wierzchołek jest celem zwroc sciezke
        if node == end: return path

        if node not in visited:
            for neighbor in graph.get(node, []):
                new_path = list(path)
                new_path.append(neighbor)
                queue.append(neighbor)
                visited.add(node)

    return None


graph = {
    'A': ["B", "C"]
}