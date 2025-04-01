window.addEventListener("load", function () {
    window.cookieconsent.initialise({
        palette: {
            popup: { background: "#222" },
            button: { background: "#14a7d0" }
        },
        theme: "classic",
        content: {
            message: "Цей сайт використовує файли cookie для забезпечення найкращого досвіду користування.",
            dismiss: "Зрозуміло",
            link: "Дізнатися більше",
            href: "/PRIVACY_POLICY.txt"
        }
    });
});
