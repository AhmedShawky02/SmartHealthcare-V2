export async function action({ request, params }) {

    const token = localStorage.getItem("token");

    if (!token) {
        return { message: "Unauthorized ❌" };
    }

    const formData = await request.formData();

    const bookingData = {
        name: formData.get("name"),
        email: formData.get("email"),
        age: formData.get("age"),
    };

    try {

        const response = await fetch("https://carefirst-v1.runasp.net/api/Users", {
            method: "PUT",
            headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${token}`
            },
            body: JSON.stringify(bookingData)
        });


        const contentType = response.headers.get("content-type");
        let responseData;

        if (contentType && contentType.includes("application/json")) {
            responseData = await response.json();
        } else {
            responseData = await response.text();
        }


        if (!response.ok) {
            return { message: responseData.message || responseData || "Saving failed ❌" };
        }

        return { message: responseData.message || "Saving successfully! ✅" };


    } catch (error) {
        return { message: `Something went wrong: ${error.message} ❌` };
    }
}
