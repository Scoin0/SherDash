let entryIndex = 1;

function addEntry() {
    const container = document.getElementById("entry-list");

    const entryDiv = document.createElement("div");
    entryDiv.className = "entry-item";

    // Create label + input
    const label = document.createElement("label");
    label.textContent = "Entry:";

    const input = document.createElement("input");
    input.name = `Changes[${entryIndex}].Entry`;
    input.placeholder = "Entry";

    // Clone the hidden Razor-generated <select>
    const template = document.getElementById("change-type-template");
    const select = template.firstElementChild.cloneNode(true);
    select.name = `Changes[${entryIndex}].ChangeType`;

    // Create type label
    const typeLabel = document.createElement("label");
    typeLabel.textContent = "Type:";

    // Append all parts
    entryDiv.appendChild(label);
    entryDiv.appendChild(input);
    entryDiv.appendChild(typeLabel);
    entryDiv.appendChild(select);

    container.appendChild(entryDiv);
    entryIndex++;
}
