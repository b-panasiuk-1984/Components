"use strict";

(() => {
    const status = document.querySelector("#posting-status");
    const table = document.querySelector("#posting-table");
    const tableBody = table.querySelector("tbody");
    const saveButton = document.querySelector("#save-button");
    const updateFields = [
        "from",
        "to",
        "content",
        "deliveryType",
        "weight",
        "width",
        "height",
        "depth",
        "value",
        "price"
    ];
    const textFields = new Set(["from", "to", "content"]);
    const positiveFields = new Set(["weight", "width", "height", "depth"]);
    const fieldNames = {
        id: "Номер",
        from: "Відправник",
        to: "Одержувач",
        content: "Вміст",
        deliveryType: "Тип доставки",
        weight: "Вага",
        width: "Ширина",
        height: "Висота",
        depth: "Глибина",
        value: "Оголошена вартість",
        price: "Вартість доставки",
        createdAt: "Дата створення"
    };
    let postingId;

    function showValidationError(message, input) {
        status.textContent = message;
        status.classList.add("error");
        input?.setAttribute("aria-invalid", "true");
        input?.focus();
    }

    function clearValidationState() {
        for (const input of tableBody.querySelectorAll("[aria-invalid='true']")) {
            input.removeAttribute("aria-invalid");
        }
        status.textContent = "";
        status.classList.remove("error");
    }

    tableBody.addEventListener("input", clearValidationState);

    document.querySelector("#back-button").addEventListener("click", () => {
        window.location.href = "index.html";
    });

    saveButton.addEventListener("click", async () => {
        clearValidationState();
        const payload = {};

        for (const field of updateFields) {
            const input = tableBody.querySelector(`input[name="${field}"]`);
            if (!input) {
                showValidationError(`У таблиці немає поля «${fieldNames[field]}».`);
                return;
            }

            if (textFields.has(field)) {
                payload[field] = input.value.trim();
                continue;
            }

            const value = Number(input.value.trim());
            if (input.value.trim() === "" || !Number.isFinite(value)) {
                showValidationError(`Введіть коректне числове значення для поля «${fieldNames[field]}».`, input);
                return;
            }

            payload[field] = value;
        }

        const validationError = window.PostingValidation.getError(payload);
        if (validationError) {
            showValidationError(
                validationError.message,
                tableBody.querySelector(`input[name="${validationError.field}"]`)
            );
            return;
        }

        saveButton.disabled = true;
        status.textContent = "Збереження змін...";

        try {
            const response = await fetch(`http://localhost:5001/postings/${encodeURIComponent(postingId)}`, {
                method: "PUT",
                headers: {
                    "Accept": "application/json",
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(payload)
            });

            if (!response.ok) {
                const detail = await response.text();
                throw new Error(`HTTP ${response.status}: ${detail || response.statusText}`);
            }

            window.location.href = "index.html";
        } catch (error) {
            status.textContent = `Не вдалося зберегти зміни: ${error.message}`;
            console.error("Не вдалося оновити поштове відправлення:", error);
        } finally {
            saveButton.disabled = false;
        }
    });

    try {
        const postingJson = new URLSearchParams(window.location.search).get("posting");
        if (!postingJson) {
            throw new Error("Дані відправлення не передані.");
        }

        const posting = JSON.parse(postingJson);
        if (!posting || typeof posting !== "object" || Array.isArray(posting)) {
            throw new Error("Отримано некоректні дані відправлення.");
        }
        if (posting.id === null || posting.id === undefined) {
            throw new Error("У записі відсутній номер відправлення.");
        }
        postingId = posting.id;

        for (const [field, value] of Object.entries(posting)) {
            const row = document.createElement("tr");
            const nameCell = document.createElement("th");
            nameCell.scope = "row";
            nameCell.textContent = fieldNames[field] ?? field;

            const valueCell = document.createElement("td");
            const input = document.createElement("input");
            input.type = field === "deliveryType" || positiveFields.has(field)
                || field === "value" || field === "price"
                ? "number"
                : "text";
            if (input.type === "number") {
                input.step = "any";
                if (positiveFields.has(field)) {
                    input.min = "0";
                } else if (field === "value" || field === "price") {
                    input.min = "0";
                } else {
                    input.min = "1";
                    input.max = "3";
                }
            }
            input.name = field;
            input.setAttribute("aria-label", fieldNames[field] ?? field);
            input.value = value === null || value === undefined ? "" : String(value);
            if (field === "id" || field === "createdAt") {
                input.readOnly = true;
            }
            input.addEventListener("input", clearValidationState);
            valueCell.append(input);

            row.append(nameCell, valueCell);
            tableBody.append(row);
        }

        status.textContent = "";
        table.hidden = false;
        saveButton.disabled = false;
    } catch (error) {
        status.textContent = `Не вдалося відобразити відправлення: ${error.message}`;
        console.error("Не вдалося відобразити дані відправлення:", error);
    }
})();
