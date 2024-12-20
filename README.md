# EV Application Web App

This project is a fully functioning web application designed for submitting applications for an Electric Vehicle (EV) as part of the **Informed Solutions Software Development Learning Program**. It consists of:

- A **GDS-compliant frontend**, built with the GOV.UK Prototype Kit.
- A **.NET backend**, capable of receiving, verifying, and saving application data to a SQLite database.
- The entire system is **fully containerized** using Docker, ensuring an easy and reproducible deployment process.

The backend includes **5 unit tests** that verify core functionality, ensuring that the application is robust and reliable.

---

## Key Features:
- **Frontend**: GDS-compliant user interface for submitting an EV application.
- **Backend**: A .NET-based API that processes, validates, and stores application data.
- **Containerization**: The application is fully containerized with Docker, making it easy to run and test in any environment.
- **Unit Tests**: The backend includes unit tests to ensure the integrity of the core functionality.


# Project Setup and Running Instructions

## Running the Project in Docker

### Step 1: Build the Docker Images

Start by rebuilding the Docker images for both the backend and frontend:

- **For the Backend**:
    ```bash
    docker build -t gds-backend .
    ```

- **For the Frontend**:
    ```bash
    docker build -t gds-frontend .
    ```

### Step 2: Create a Custom Docker Network

Ensure the frontend and backend containers can communicate with each other:

```bash
docker network create my_app_network
