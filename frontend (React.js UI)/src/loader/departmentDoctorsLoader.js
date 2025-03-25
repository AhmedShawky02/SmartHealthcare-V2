export async function loader({ params }) {
    const { departmentId } = params;
    try {
        const response = await fetch(`https://carefirst-v1.runasp.net/api/Doctors/by-department/${departmentId}`);

        if (!response.ok) {
            const errorText = await response.text();
            throw new Error(errorText || "Failed to fetch doctors");
        }

        return response.json();

    } catch (error) {
        console.error("Error fetching doctors:", error);
        return { error: error.message };
    }
}