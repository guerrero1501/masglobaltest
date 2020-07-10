import React, { useState } from "react";

export function Home() {
  const [data, setData] = useState(null);
  const [Loading, setLoading] = useState(false);
  const [id, setId] = useState(null);

  async function handleSubmit(e) {
    e.preventDefault();

    let response = await fetch(
      `${process.env.REACT_APP_API_URL}/Employee/` +
        (id === null || id === 0 ? "" : id)
    );
    let rta = await response.json();

    if (rta.header.code === 200) {
      setData(rta.data);
    } else {
      alert(rta.header.message);
    }
  }

  return (
    <div className="container">
      <br />
      {Loading ? (
        <span>Cargando...</span>
      ) : (
        <>
          <input
            type="text"
            placeholder="Buscar"
            onChange={(e) => setId(e.target.value)}
            value={id}
          />

          <button
            type="button"
            class="btn btn-primary"
            onClick={(e) => handleSubmit(e)}
          >
            Buscar
          </button>
          {data ? (
            <table className="table table-striped" aria-labelledby="tabelLabel">
              <thead>
                <tr>
                  <th>Id</th>
                  <th>Name</th>
                  <th>ContractTypeName</th>
                  <th>RoleId</th>
                  <th>RoleName</th>
                  <th>HourlySalary</th>
                  <th>MonthlySalary</th>
                  <th>AnnualSalary</th>
                </tr>
              </thead>
              <tbody>
                {data.map ? (
                  data.map((row) => (
                    <tr key={row.id}>
                      <td>{row.id}</td>
                      <td>{row.name}</td>
                      <td>{row.contractTypeName}</td>
                      <td>{row.roleId}</td>
                      <td>{row.roleName}</td>
                      <td>{row.hourlySalary}</td>
                      <td>{row.monthlySalary}</td>
                      <td>{row.annualSalary}</td>
                    </tr>
                  ))
                ) : (
                  <tr key={data.id}>
                    <td>{data.id}</td>
                    <td>{data.name}</td>
                    <td>{data.contractTypeName}</td>
                    <td>{data.roleId}</td>
                    <td>{data.roleName}</td>
                    <td>{data.hourlySalary}</td>
                    <td>{data.monthlySalary}</td>
                    <td>{data.annualSalary}</td>
                  </tr>
                )}
              </tbody>
            </table>
          ) : (
            <span>Sin datos</span>
          )}
        </>
      )}
    </div>
  );
}
