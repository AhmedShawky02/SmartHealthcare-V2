export async function action({ request }) {
    const formData = await request.formData();

    const email =await formData.get("email");

        console.log(email)

    try {

        const response = await fetch("https://carefirst-v1.runasp.net/api/Users/SendTokenToEmail", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(email)
        })

        const contentType = response.headers.get("content-type");
        let responseData;

        if (contentType && contentType.includes("application/json")) {
            responseData = await response.json();
        } else {
            responseData = await response.text();
        }

        console.log(responseData)

        if (!response.ok) {
            return { message: responseData.message || responseData || "failed to Change Password ❌" };
        }

        return { message: responseData.message || "Check your email" };

    } catch (error) {
        return { message: `Something went wrong: ${error.message} ❌` };
    }
}