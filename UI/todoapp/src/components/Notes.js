import React, { useState } from 'react';
import './Notes.css';

function Notes({ notes, onAdd, onDelete }) {
    const [ newNote, setNewNote ] = useState("");

    const handleAddClick = () => {
        onAdd(newNote);
        setNewNote(""); // Clear the input field after adding
    };

    return (
        <div>
            <div className="input-div">
                <input id="newNotes" value={newNote} onChange={e => setNewNote(e.target.value) }></input>
                <button onClick={handleAddClick} type="button" class="btn btn-primary">Add Note</button>
            </div>

            <ul className="list">
                {notes.map(note =>
                    <li key={note.id }>
                            <div className="list-item">
                                <span>{note.description}</span>
                                <button onClick={() => onDelete(note.id)} type="button" class="btn btn-danger">Delete</button>
                            </div>
                        </li>
                )}
            </ul>
        </div>
    )
}
export default Notes;