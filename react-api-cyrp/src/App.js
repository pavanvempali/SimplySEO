import React, {useState} from 'react';
import './App.css';
import axios from 'axios';

function App() {
  const [count, setCount]= useState([]);
  const [search, setSearch]= useState('e-settlements');
  const [searchengine, setSearchEngine]= useState('Google');

  const  onOptionChange = async e => {
    setSearchEngine(e.target.value );
  };
  
  const onTextChange = async e => {
    setSearch( e.target.value );
  };

  function  performSearch(e) {
      if(search==="" || search===undefined)
      { 
          alert("Enter a search value");
          return;
      }
      e.preventDefault();
      axios.get('http://localhost:62486/api/search/'+ search.toLocaleLowerCase()+ '/'+searchengine.toLocaleLowerCase())
      .then(res => {
            setCount (res.data);
        }).catch(error => console.log(error))
  }
 
  return (
    <div className="count-app">
      <div className="count-search">
        <h1 className="count-text">
              Enter a search term to get its appearance in top 100 results
        </h1>   
        <form>
            <select 
            value={searchengine} 
            onChange={onOptionChange} 
            className="count-input"
            >
          <option value="Google">Google</option>
          <option value="Bing">Bing</option>
          
          </select>
          &nbsp;&nbsp;
                <input type="text" value={search} placeholder="Search" className="count-input" onChange={onTextChange} />
                &nbsp;&nbsp;
                <button className="btn-go" onClick={(e)=> {performSearch(e)}}>Go</button>
        </form>
      </div>
    
   <h1 className="count-value">{count}</h1>
   </div>
  );
}

export default App;
