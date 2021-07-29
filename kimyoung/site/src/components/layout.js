import React from "react"

const Layout = props => {
  return (
    <div
      style={{
        backgroundColor: "#fff",
        overflowY: "hidden",
        position: "relative",
        display: "flex",
        flexDirection: "column",
        width: "100%",
        height: "100%",
      }}
    >
      {props.children}
    </div>
  )
}

export default Layout
