import React from "react";
import { Route, Switch } from "react-router-dom";
import { Home } from "./views/home";
import App from "./App";

const AppRoutes = () => {
  return (
    <App>
      <Switch>
        <Route exact path="/" component={Home} />
      </Switch>
    </App>
  );
};

export default AppRoutes;
