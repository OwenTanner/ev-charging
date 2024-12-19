# Use a Node.js image
FROM node:18

# Set the working directory inside the container
WORKDIR /app

# Copy your GDS prototype files into the container
COPY . .

# Install dependencies
RUN npm install

# Expose the default GDS port
EXPOSE 3000

# Command to start the GDS prototype
CMD ["npm", "run", "dev"]
