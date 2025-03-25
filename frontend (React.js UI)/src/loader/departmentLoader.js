export async function loader() {
    try {
        const response = await fetch("https://carefirst-v1.runasp.net/api/Departments/GetAll");
        return await response.json();
    } catch (error) {
        console.error("Error fetching specialties:", error);
    }
}
