import React, { Component } from "react";
import { Navbar, Nav, NavDropdown } from "react-bootstrap";

export const CustomNav = () => {
  return (
    <Navbar collapseOnSelect expand="lg" bg="dark" variant="dark">
      <Navbar.Brand href="/">
        <img
          src={`${window.location.origin}/logo192.png`}
          width="100"
          height="90"
          className="d-inline-block align-top"
        />
      </Navbar.Brand>
      <Navbar.Toggle aria-controls="responsive-navbar-nav" />
      <Navbar.Collapse id="responsive-navbar-nav"></Navbar.Collapse>
    </Navbar>
  );
};
