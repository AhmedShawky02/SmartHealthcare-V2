export async function loader() {

    const token = localStorage.getItem("token");

    if (!token) {
        return { message: "Unauthorized ❌" };
    }

    try {
        const response = await fetch("https://carefirst-v1.runasp.net/api/Users/me",{
            method: "Get",
            headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${token}`
            },
        });

        const contentType = response.headers.get("content-type");
        let responseData;

        if (contentType && contentType.includes("application/json")) {
            responseData = await response.json();
        } else {
            responseData = await response.text();
        }


        if (!response.ok){
            return { message: responseData.message || responseData || "failed ❌" };
        }

        return responseData ;

    } catch (error) {
        console.error("Error loading data:", error);
        return { responseData: null };
    }
}