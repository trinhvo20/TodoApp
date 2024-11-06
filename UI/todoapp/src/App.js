import './App.css';
import { Component } from 'react';
import Notes from './components/Notes';
import { addNote, deleteNote, fetchNotes } from './api';

class App extends Component {
    constructor(props) {
        super(props);
        this.state = {
            notes: []
        }
    }
    
    componentDidMount() {
        this.refreshNotes()    
    }

    // Call API to get all notes
    async refreshNotes() {
        const notes = await fetchNotes();
        this.setState({ notes });
    }

    async handleAddNote(newNotes) {
        await addNote(newNotes);
        this.refreshNotes();
    }

    async handleDeleteNote(id) {
        await deleteNote(id);
        this.refreshNotes();
    }

    render() {
        const { notes } = this.state;
        return (
            <div className="App">
                <h2>Todo App</h2>
                <Notes
                    notes={notes}
                    onAdd={newNotes => this.handleAddNote(newNotes)}
                    onDelete={id => this.handleDeleteNote(id) } />

            </div>
        );
    }

}
export default App;
