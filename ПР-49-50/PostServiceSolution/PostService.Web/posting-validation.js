"use strict";

(() => {
    const deliveryTypes = new Set([1, 2, 3]);
    const positiveFields = new Set(["weight", "width", "height", "depth"]);
    const nonNegativeFields = new Set(["value", "price"]);
    const fieldNames = {
        from: "Відправник",
        to: "Одержувач",
        content: "Вміст",
        deliveryType: "Тип доставки",
        weight: "Вага",
        width: "Ширина",
        height: "Висота",
        depth: "Глибина",
        value: "Оголошена вартість",
        price: "Вартість доставки"
    };

    function getError(posting) {
        for (const field of ["from", "to", "content"]) {
            if (typeof posting[field] !== "string" || posting[field].trim() === "") {
                return {
                    field,
                    message: `Поле «${fieldNames[field]}» не може бути порожнім.`
                };
            }
        }

        if (!deliveryTypes.has(Number(posting.deliveryType))) {
            return {
                field: "deliveryType",
                message: "Оберіть один із доступних типів доставки."
            };
        }

        for (const field of positiveFields) {
            const value = Number(posting[field]);
            if (!Number.isFinite(value) || value <= 0) {
                return {
                    field,
                    message: `Поле «${fieldNames[field]}» має бути числом більшим за нуль.`
                };
            }
        }

        for (const field of nonNegativeFields) {
            if (posting[field] === undefined) {
                continue;
            }

            const value = Number(posting[field]);
            if (!Number.isFinite(value) || value < 0) {
                return {
                    field,
                    message: `Поле «${fieldNames[field]}» має бути невід’ємним числом.`
                };
            }
        }

        return null;
    }

    window.PostingValidation = Object.freeze({ getError });
})();
