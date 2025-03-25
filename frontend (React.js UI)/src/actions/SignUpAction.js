export async function action({ request, params }) {
    const formData = await request.formData();

    const bookingData = {
        name: formData.get("name"),
        email: formData.get("email"),
        password: formData.get("password"),
        age: formData.get("age"),
        gender: formData.get("gender")
    };

    try {

        const response = await fetch("https://carefirst-v1.runasp.net/api/Users/register", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
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
            return { message: responseData.message || responseData || "Sign Up failed ❌" };
        }

        localStorage.setItem("token" ,responseData.token)
        const expiration = new Date();
        expiration.setHours(expiration.getHours() + 48);
        localStorage.setItem('expiration', expiration.toISOString());

        return { message: responseData.message || "Sign Up successfully! ✅" };

    } catch (error) {
        return { message: `Something went wrong: ${error.message} ❌` };
    }
}   