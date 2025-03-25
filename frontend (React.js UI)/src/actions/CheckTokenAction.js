export async function action({ request }) {
    const formData = await request.formData();

    const tokenUser = [
        formData.get("token-0"),
        formData.get("token-1"),
        formData.get("token-2"),
        formData.get("token-3"),
        formData.get("token-4"),
    ].join("");

    const emailUser = formData.get("email")

    const data = {
        email: emailUser,
        token: tokenUser
    }

    console.log(data)

    try {

        const response = await fetch("https://carefirst-v1.runasp.net/api/Users/VerifyToken", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(data)
        });

        const contentType = response.headers.get("content-type");
        let responseData;

        if (contentType && contentType.includes("application/json")) {
            responseData = await response.json();
        } else {
            responseData = await response.text();
        }

        if (!response.ok) {
            return { message: responseData.message || responseData || "Token verification failed ❌" };
        }

        return { token: tokenUser, message: responseData.message || responseData || "Token Is valid ✅" };

    } catch (error) {
        return { message: `Something went wrong: ${error.message} ❌` };
    }

}