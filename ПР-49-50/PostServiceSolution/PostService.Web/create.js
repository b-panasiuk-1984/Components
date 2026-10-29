"use strict";

(() => {
    const form = document.querySelector("#create-form");
    const status = document.querySelector("#create-status");
    const submitButton = document.querySelector("#submit-button");
    const numericFields = ["weight", "width", "height", "depth", "value"];

    function clearValidationState() {
        for (const input of form.querySelectorAll("[aria-invalid='true']")) {
            input.removeAttribute("aria-invalid");
        }
        status.textContent = "";
        status.classList.remove("error");
    }

    form.addEventListener("input", clearValidationState);
    form.addEventListener("change", clearValidationState);

    document.querySelector("#cancel-button").addEventListener("click", () => {
        window.location.href = "index.html";
    });

    form.addEventListener("submit", async (event) => {
        event.preventDefault();
        clearValidationState();
        const formData = new FormData(form);
        const posting = {
            from: formData.get("from").trim(),
            to: formData.get("to").trim(),
            content: formData.get("content").trim(),
            deliveryType: formData.get("deliveryType") === ""
                ? Number.NaN
                : Number(formData.get("deliveryType"))
        };

        for (const field of numericFields) {
            const value = formData.get(field).trim();
            posting[field] = value === "" ? Number.NaN : Number(value);
        }

        const validationError = window.PostingValidation.getError(posting);
        if (validationError) {
            status.textContent = validationError.message;
            status.classList.add("error");
            const invalidInput = form.elements.namedItem(validationError.field);
            invalidInput.setAttribute("aria-invalid", "true");
            invalidInput.focus();
            return;
        }

        submitButton.disabled = true;
        status.textContent = "Створення відправлення...";

        try {
            const response = await fetch("http://localhost:5001/postings", {
                method: "POST",
                headers: {
                    "Accept": "application/json",
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(posting)
            });

            if (!response.ok) {
                const detail = await response.text();
                throw new Error(`HTTP ${response.status}: ${detail || response.statusText}`);
            }

            window.location.href = "index.html";
        } catch (error) {
            status.textContent = `Не вдалося створити відправлення: ${error.message}`;
            console.error("Не вдалося створити поштове відправлення:", error);
            submitButton.disabled = false;
        }
    });
})();
