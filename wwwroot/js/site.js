let entryIndex = 1;

function addEntry() {
    const container = document.getElementById("entry-list");

    const entryDiv = document.createElement("div");
    entryDiv.className = "entry-item";

    // Entry label + input
    const label = document.createElement("label");
    label.textContent = "Entry:";

    const input = document.createElement("input");
    input.className = "form-control";
    input.name = `Changes[${entryIndex}].Entry`;
    input.placeholder = "Entry";

    // Type label + select
    const typeLabel = document.createElement("label");
    typeLabel.textContent = "Type:";

    const template = document.getElementById("change-type-template");
    const select = template.firstElementChild.cloneNode(true);
    select.name = `Changes[${entryIndex}].ChangeType`;
    select.className = "form-control";

    // Append all
    entryDiv.appendChild(label);
    entryDiv.appendChild(input);
    entryDiv.appendChild(typeLabel);
    entryDiv.appendChild(select);

    container.appendChild(entryDiv);
    entryIndex++;
}