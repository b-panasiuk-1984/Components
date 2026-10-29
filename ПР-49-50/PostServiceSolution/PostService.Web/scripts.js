"use strict";

(() => {
    const baseUrl = "http://localhost:5001/";
    const postingsUrl = new URL("postings", baseUrl).toString();

    async function request(url, options = {}) {
        const headers = new Headers(options.headers);
        headers.set("Accept", "application/json");

        if (options.body !== undefined) {
            headers.set("Content-Type", "application/json");
        }

        const response = await fetch(url, { ...options, headers });
        const responseText = await response.text();
        let responseData = null;

        if (responseText) {
            try {
                responseData = JSON.parse(responseText);
            } catch {
                responseData = responseText;
            }
        }

        if (!response.ok) {
            const detail = typeof responseData === "string"
                ? responseData
                : responseData?.title ?? responseData?.detail ?? response.statusText;
            throw new Error(`HTTP ${response.status}: ${detail}`);
        }

        return responseData;
    }

    window.PostServiceApi = Object.freeze({
        getAll: () => request(postingsUrl),

        getById: (id) => request(`${postingsUrl}/${encodeURIComponent(id)}`),

        create: (posting) => request(postingsUrl, {
            method: "POST",
            body: JSON.stringify(posting)
        }),

        update: (id, posting) => request(`${postingsUrl}/${encodeURIComponent(id)}`, {
            method: "PUT",
            body: JSON.stringify(posting)
        }),

        delete: (id) => request(`${postingsUrl}/${encodeURIComponent(id)}`, {
            method: "DELETE"
        })
    });

    const status = document.querySelector("#postings-status");
    const table = document.querySelector("#postings-table");
    const tableHead = table.querySelector("thead");
    const tableBody = table.querySelector("tbody");
    const aboutDialog = document.querySelector("#about-dialog");
    document.querySelector("#create-posting-button").addEventListener("click", () => {
        window.location.href = "create.html";
    });
    document.querySelector("#about-button").addEventListener("click", () => {
        aboutDialog.showModal();
    });
    document.querySelector("#close-about-button").addEventListener("click", () => {
        aboutDialog.close();
    });
    const columnNames = {
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
    const dateFormatter = new Intl.DateTimeFormat("uk-UA", {
        dateStyle: "medium",
        timeStyle: "short"
    });

    function renderPostings(postings) {
        if (!Array.isArray(postings)) {
            throw new Error("Сервер повернув дані у неочікуваному форматі.");
        }

        tableHead.replaceChildren();
        tableBody.replaceChildren();

        if (postings.length === 0) {
            status.textContent = "Поштових відправлень не знайдено.";
            table.hidden = true;
            return;
        }

        const columns = Object.keys(postings[0]);
        const headerRow = document.createElement("tr");

        for (const column of columns) {
            const header = document.createElement("th");
            header.scope = "col";
            header.textContent = columnNames[column] ?? column;
            headerRow.append(header);
        }
        const actionsHeader = document.createElement("th");
        actionsHeader.scope = "col";
        actionsHeader.textContent = "Дії";
        headerRow.append(actionsHeader);
        tableHead.append(headerRow);

        for (const posting of postings) {
            const row = document.createElement("tr");

            for (const column of columns) {
                const cell = document.createElement("td");
                const value = posting[column];
                cell.textContent = value === null || value === undefined
                    ? ""
                    : column === "createdAt" && !Number.isNaN(Date.parse(value))
                        ? dateFormatter.format(new Date(value))
                        : String(value);
                row.append(cell);
            }

            const actionsCell = document.createElement("td");
            const editButton = document.createElement("button");
            editButton.type = "button";
            editButton.setAttribute("aria-label", "Редагувати");
            editButton.title = "Редагувати";
            editButton.append(createActionIcon("M12 20h9 M16.5 3.5a2.1 2.1 0 0 1 3 3L8 18l-4 1 1-4Z"));
            editButton.addEventListener("click", () => {
                const editUrl = new URL("edit.html", window.location.href);
                editUrl.searchParams.set("posting", JSON.stringify(posting));
                const editWindow = window.open(editUrl, "_blank");

                if (!editWindow) {
                    status.textContent = "Дозвольте відкривати спливаючі вікна, щоб передати дані.";
                }
            });

            const deleteButton = document.createElement("button");
            deleteButton.type = "button";
            deleteButton.setAttribute("aria-label", "Видалити");
            deleteButton.title = "Видалити";
            deleteButton.append(createActionIcon("M3 6h18 M8 6V4h8v2 M19 6l-1 14H6L5 6 M10 11v5 M14 11v5"));
            deleteButton.addEventListener("click", async () => {
                deleteButton.disabled = true;
                status.textContent = `Видалення відправлення №${posting.id}...`;

                try {
                    const remainingPostings = await window.PostServiceApi.delete(posting.id);
                    renderPostings(remainingPostings);
                } catch (error) {
                    status.textContent = `Не вдалося видалити відправлення: ${error.message}`;
                    deleteButton.disabled = false;
                    console.error("Не вдалося видалити поштове відправлення:", error);
                }
            });

            actionsCell.append(editButton, deleteButton);
            row.append(actionsCell);
            tableBody.append(row);
        }

        status.textContent = "";
        table.hidden = false;
    }

    function createActionIcon(pathData) {
        const svgNamespace = "http://www.w3.org/2000/svg";
        const icon = document.createElementNS(svgNamespace, "svg");
        icon.setAttribute("viewBox", "0 0 24 24");
        icon.setAttribute("fill", "none");
        icon.setAttribute("stroke", "currentColor");
        icon.setAttribute("stroke-width", "2");
        icon.setAttribute("stroke-linecap", "round");
        icon.setAttribute("stroke-linejoin", "round");
        icon.setAttribute("aria-hidden", "true");

        const path = document.createElementNS(svgNamespace, "path");
        path.setAttribute("d", pathData);
        icon.append(path);

        return icon;
    }

    window.PostServiceApi.getAll()
        .then(renderPostings)
        .catch((error) => {
            status.textContent = `Не вдалося завантажити дані: ${error.message}`;
            console.error("Не вдалося завантажити поштові відправлення:", error);
        });
})();
