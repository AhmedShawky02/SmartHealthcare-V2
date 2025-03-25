export async function homeLoader() {
    try {
        const [departmentsResponse , diseasesResponse] = await Promise.all([
            fetch("https://carefirst-v1.runasp.net/api/Departments/GetAll"),
            fetch("https://carefirst-v1.runasp.net/api/Diseases/GetAllDisease"),

        ]);

        const departments = departmentsResponse.ok ? await departmentsResponse.json() : [];
        const diseases = diseasesResponse.ok ? await diseasesResponse.json() : [];

        if (!departmentsResponse.ok) {
            console.error("Failed to fetch departments:", departmentsResponse.status);
        }

        if (!diseasesResponse.ok) {
            console.error("Failed to fetch diseases:", diseasesResponse.status);
        }

        return { departments ,diseases};

    } catch (error) {
        console.error("Error loading data:", error.message);
        return { departments: [] , diseases: []};
    }
}