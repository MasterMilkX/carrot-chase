import random

def generate_maze(width, height):
    # Create a grid filled with walls (1)
    maze = [[1 for _ in range(width)] for _ in range(height)]

    def carve_passages(x, y):
        directions = [(0, -2), (2, 0), (0, 2), (-2, 0)]  # Directions: N, E, S, W
        random.shuffle(directions)  # Randomize directions

        for dx, dy in directions:
            nx, ny = x + dx, y + dy

            # Check if the next cell is within bounds and unvisited
            if 0 <= nx < width and 0 <= ny < height and maze[ny][nx] == 1:
                # Carve a path between the current cell and the next cell
                maze[y + dy // 2][x + dx // 2] = 0  # Remove the wall
                maze[ny][nx] = 0  # Mark the next cell as visited
                carve_passages(nx, ny)  # Recurse from the next cell

    # Start carving from a random position
    start_x, start_y = random.randrange(1, width, 2), random.randrange(1, height, 2)
    maze[start_y][start_x] = 0
    carve_passages(start_x, start_y)

    return maze

def print_maze(maze):
    for row in maze:
        print(",".join(str(cell) for cell in row))

# Example usage
if __name__ == "__main__":
    width, height = 14,14  # Dimensions of the maze (must be odd)
    maze = generate_maze(width, height)
    print_maze(maze)
