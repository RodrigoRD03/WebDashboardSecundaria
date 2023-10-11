let password = document.querySelector(".input-password-su");
let iconEye = document.querySelector(".IconEye-su");

iconEye.addEventListener("click", () => {
    if (password.type == "password") {
        password.type = "text";
        iconEye.innerHTML = `<i class="fa-solid fa-eye"></i>`
    } else {
        password.type = "password";
        iconEye.innerHTML = `<i class="fa-solid fa-eye-slash"></i>`
    }
})