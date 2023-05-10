import React from "react";

interface TitleProps {
  title: string;
  children?: React.ReactNode;
}

const Title: React.FC<TitleProps> = ({ title, children }: TitleProps) => {
  return (
    <div className="d-flex justify-content-between align-items-end border-bottom border-1 mt-2 pb-3">
      <h1 className="p-0 m-0">{title}</h1>
      {children}
    </div>
  );
};
export default Title;
