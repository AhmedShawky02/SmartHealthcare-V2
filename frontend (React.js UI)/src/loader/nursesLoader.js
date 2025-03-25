export async function loader() {
    try {
        const response = await fetch("https://carefirst-v1.runasp.net/api/Nurses/GetAll");

        if (!response.ok) {
            console.error("Failed to fetch nurses:", response.status);
            return { doctors: [] };
        }

        const doctors = await response.json();
        return  doctors ;

    } catch (error) {
        console.error("Error loading data:", error.message);
        return { doctors: [] };
    }
}