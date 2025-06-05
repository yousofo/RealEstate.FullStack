"use client";
import * as React from "react";
import { DataGrid, GridColDef } from "@mui/x-data-grid";
import Paper from "@mui/material/Paper";
import { Container } from "@mui/material";
import { useEffect, useState } from "react";
import clientFetch from "@/utils/client-fetch";
import { toast } from "react-toastify";
import Link from "next/link";
import PageBreadcrumb from "@/components/common/PageBreadCrumb";
import ComponentCard from "@/components/common/ComponentCard";

const columns: GridColDef[] = [
    { field: "id", headerName: "ID", width: 70 },
    { field: "title", headerName: "First name", width: 130 },
    { field: "price", headerName: "Last name", width: 130 },
    {
        field: "description",
        headerName: "Age",
        type: "number",
        width: 90,
    },
    {
        field: "thumbnail",
        headerName: "Full name",
        description: "This column has a value getter and is not sortable.",
        sortable: false,
        width: 160,

        valueGetter: (value, row) =>
            `${row.firstName || ""} ${row.lastName || ""}`,
    },
];

const paginationModel = { page: 0, pageSize: 5 };

const Properties = () => {
    const [properties, setProperties] = useState([]);

    useEffect(() => {
        console.log("env", process.env.NEXT_PUBLIC_API_URL);
        clientFetch()
            .then((res) => res.json())
            .then((data) => {
                setProperties(data);
                console.log(data);
            })
            .catch((err) => {
                toast.error("Error fetching data", {
                    autoClose: false,
                    className:
                        "shadow-lg! shadow-red-200! border-red-100! border-2",
                });
                console.log("Error fetching data", err);
            });
    }, []);
    return (
        <div>
            <PageBreadcrumb pageTitle="Properties" />
            <div className="space-y-6">
                <ComponentCard title="Properties Table" desc="This is a table of properties fetched from the API.">
                    <DataGrid
                        rows={properties}
                        columns={columns}
                        initialState={{ pagination: { paginationModel } }}
                        pageSizeOptions={[10, 10]}
                        checkboxSelection
                        sx={{ border: 0 }}
                    />
                </ComponentCard>
            </div>
        </div>
        // <Container maxWidth="xl">
        //     <Paper sx={{ height: 400, width: "100%" }}>

        //     </Paper>
        // </Container>
    );
};

export default Properties;
/*
 */
