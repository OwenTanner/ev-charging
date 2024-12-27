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

---

## Running the Project in Docker

### Step 0: Clear docker. 
Run the following in order to clean away previous docker images. 
```bash
docker system prune
```

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
```

### Step 3: Run the Backend Container

Start the backend container, linking it to the custom network:

```bash
docker run -d --network my_app_network --name backend-container gds-backend
```

### Step 4: Run the Frontend Container

Start the frontend container and link it to the same network:

```bash
docker run -d --network my_app_network --name frontend-container -p 3000:3000 gds-frontend
```

- This command maps **port 3000** in the container to **localhost:3000** on your host, making the frontend accessible in your browser.

### Step 5: Verify the Containers Are Running

Use this command to check that both containers are running:

```bash
docker ps
```

### Step 6: Test the Application

1. Open your browser and go to `http://localhost:3000`.
2. Submit a form and check if the **confirmation page** appears.
3. To verify if the data has been inserted into the database, run the following command to check the database inside the backend container (EvChargingApp):
    ```bash
    docker exec -it backend-container sh
    sqlite3 /app/applications.db
    SELECT * FROM Applications;
    ```
4. Alternatively (again within EVChargingApp) run the following to clone in the database so that you can view it.
   ```bash
    docker cp backend-container:/app/applications.db ./applications.db
   ```

### Step 7: Clean Up After Testing

When you're done testing, stop and remove the containers:

```bash
docker stop frontend-container backend-container
docker rm frontend-container backend-container
```

You can also remove the custom network if you no longer need it:

```bash
docker network rm my_app_network
```

---

## Running the Project Locally

### Step 1: Start the Frontend

In the main folder of the project, run:

```bash
npm run dev
```

This will start the frontend on `http://localhost:3000`.

### Step 2: Start the Backend

1. Change directory to `EvChargingApp`:

    ```bash
    cd EvChargingApp
    ```

2. Run the following commands to build and start the backend:

    ```bash
    dotnet build
    dotnet run
    ```

This will start the backend on `http://localhost:5051`.

### Step 3: Test the Application

1. Open your browser and go to `http://localhost:3000` to access the frontend.
2. Submit a form and check if the **confirmation page** appears.
3. To check the database locally, you can run the following command from within the `EvChargingApp` folder:
    ```bash
    sqlite3 applications.db
    SELECT * FROM Applications;
    ```
4. Alternatively, running the following command will copy the database into the working directory.
   ```bash
   docker cp backend-container:/app/applications.db ./applications.db
   ```
---

## Summary of Key Commands

- **Build Backend Image**: `docker build -t gds-backend .`
- **Build Frontend Image**: `docker build -t gds-frontend .`
- **Run Backend in Docker**: `docker run -d --network my_app_network --name backend-container gds-backend`
- **Run Frontend in Docker**: `docker run -d --network my_app_network --name frontend-container -p 3000:3000 gds-frontend`
- **Check Container Status**: `docker ps`
- **View Database in Docker**: `docker exec -it backend-container sh` → `sqlite3 /app/applications.db` → `SELECT * FROM Applications;`
- **Run Frontend Locally**: `npm run dev`
- **Run Backend Locally**: `cd EvChargingApp` → `dotnet build` → `dotnet run`

---


