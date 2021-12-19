import 'bootstrap/dist/css/bootstrap.min.css';
import React, { useState } from "react";

function App() {

  const [result, setResult] = useState("Your result will appear here!");
  const [userInput, setUserInput] = useState("");
  const [typeOfConversion, setTypeOfConversion] = useState("");

  let apiUrl = `https://localhost:44356/api/numbers-to-words/`;

  const sendGetRequest = async () => {
    await fetch(`${apiUrl}${typeOfConversion}`, {
      method: "POST",
      mode: "cors",
      cache: "no-cache",
      credentials: "same-origin",
      headers: { "Content-Type": "application/json" },
      redirect: "follow",
      referrerPolicy: "no-referrer",
      body: JSON.stringify({ Input: userInput })
    })
      .then((resp) => resp.json())
      .then((data) => setResult(data.result))
  }

  return (
    <>
      <div className="d-flex flex-wrap">
        <label className="mx-4 my-3 font-weight-bold">
          Convert numbers to words and vice versa!
        </label>
      </div>
      <div className="d-flex flex-column flex-wrap ">
        <input type="text" name="name" className="mx-4 my-3" onChange={(e) => setUserInput(e.target.value)} />
        <div className="d-flex flex-column flex-wrap mx-4 my-3 justify-content-center align-items-center" onChange={(e) => setTypeOfConversion(e.target.value)}>
          <label>Choose a conversion method:</label>
          <select id="typeOfConversion">
            <option value="">Numbers to words</option>
            <option value="vice-versa">Words to numbers</option>
          </select>
        </div>
        <button
          onClick={() => sendGetRequest()}
          type="button"
          className="mx-4 my-3 btn btn-primary btn-sm">
          Convert!
        </button>
      </div>
      <div className="d-flex flex-wrap mx-4 my-3 justify-content-center align-items-center">
        <span id="resultSpan" className="font-weight-bold">
          {result}
        </span>
      </div>
    </>
  );
}

export default App;
