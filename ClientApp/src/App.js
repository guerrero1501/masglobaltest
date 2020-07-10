import React from "react";
import logo from "./logo.svg";
import "./App.css";
import "@fortawesome/fontawesome-free/css/all.min.css";
import $ from "jquery";
import Popper from "popper.js";
import "bootstrap/dist/js/bootstrap.bundle.min";
import "bootstrap-css-only/css/bootstrap.min.css";
import "mdbreact/dist/css/mdb.css";
import "@devexpress/dx-react-grid-bootstrap4/dist/dx-react-grid-bootstrap4.css";
import "devextreme/dist/css/dx.common.css";
import "devextreme/dist/css/dx.light.css";
import { CustomNav } from "./components/Navbar";

function App(props) {
  const { children } = props;
  return (
    <div className="App">
      <CustomNav />
      {children}
    </div>
  );
}

export default App;
