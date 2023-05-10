import React from "react";
import { Button } from 'react-bootstrap';

export default function Title({title, children}){
    return(        
      <div className="d-flex justify-content-between align-items-end border-bottom border-1 mt-2 pb-3">
      <h1 className="p-0 m-0">
            {title}
      </h1>
      {children}
    </div>
    );
}