export async function action({ request }) {
    const formData = await request.formData();

    const token = formData.get("token").split(",").join("");

    const data = {
        tokenOTP: token,
        password: formData.get("newPassword"),
        confirmPassword: formData.get("confirmPassword")
    }

    try {

        const response = await fetch("https://carefirst-v1.runasp.net/api/Users/ResetPassword", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
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
            return { message: responseData.message || responseData || "Password updated failed ❌" };
        }

        return { message: responseData.message|| responseData || "Password updated successfully ✅" };

    } catch (error) {
        return { message: `Something went wrong: ${error.message} ❌` };
    }

}