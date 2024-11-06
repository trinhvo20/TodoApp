const API_URL = "http://localhost:5019/";

// Call API to get all notes
export async function fetchNotes() {
    const response = await fetch(API_URL + "api/TodoApp/GetNotes");
    return response.json();
}

// Call API to get add a note
export async function addNote(newNotes) {
    const data = new FormData();
    data.append("newNotes", newNotes);

    const response = await fetch(API_URL + "api/TodoApp/AddNotes", {
        method: "POST",
        body: data
    });
    return response.json();
}

// Call API to get delete a note
export async function deleteNote(id) {
    const response = await fetch(API_URL + "api/TodoApp/DeleteNotes?id=" + id, {
        method: "DELETE",
    });
    return response.json();
}
